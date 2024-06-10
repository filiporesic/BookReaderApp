--------------------------------------------------------------------------------------------- baza

CREATE TABLE Users (
    UserId SERIAL PRIMARY KEY,
    Username VARCHAR(20) NOT NULL UNIQUE,
    Email VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL
);

CREATE TABLE Books (
    BookId SERIAL PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Author VARCHAR(100) NOT NULL,
    Other json,
    Price DECIMAL(10, 2) NOT null CHECK ( price >= 0 ),
    UNIQUE (Title, Author)
);

CREATE TABLE Wallets (
    WalletId SERIAL PRIMARY KEY,
    UserId INT,
    Amount DECIMAL(10, 2) CHECK ( amount >= 0 ),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Transactions (
    TransactionId SERIAL PRIMARY KEY,
    UserId INT,
    BookId INT,
    Amount  DECIMAL(10, 2) NOT null CHECK ( amount >= 0 ),
    BorrowDate DATE NOT NULL,
    ReturnDate DATE,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);




--------------------------------------------------------------------------------------------- funkcije




-- NAPLATA POSUDBE

create or replace function wallet_check () returns trigger as $$
begin 
	  if( new.amount >= 
	       ( select sum(amount) from wallets 
	                            where wallets.userid = new.userid) )  then  
	           raise exception 'Korisnik nema dovoljno sredstva u novčaniku!';
	  end if;
	  return null;
end;
$$ language plpgsql;




create trigger check_buy 
  before insert on transactions
  for each row 
     execute function wallet_check();
    
    
     
    
create or replace procedure posudba (   
       x_bookid INT,
       x_userid INT) AS $$
declare 
    x_amount decimal(10,2);
    wid      int;
    wam      decimal(10,2);
begin 
	if not exists (select * from books where  bookid = x_bookid) then  
	         raise exception 'Nepostojeća knjiga u transakciji!';
	end if;
    if not exists (select * from users where  userid = x_userid) then   
             raise exception 'Nepostojeći korisnik u transakciji!';
    end if;
   
   
 	select price
 	    into x_amount
 	    from books
 	    where bookid = x_bookid;
    
 	insert into transactions(BookID, UserID, Amount, BorrowDate, ReturnDate) values
 	(x_bookid, x_userid, x_amount, current_timestamp, current_timestamp + interval '1 month');
 
   
    for wid,wam in 
                select walletid,amount from wallets 
                                where wallets.userid = x_userid 
                                order by amount DESC
         loop 
	         if( wam >= x_amount ) then 
	             update wallets set amount = amount - x_amount where wallets.walletid = wid;
	             exit;
	         else 
	            update wallets set amount = 0 where wallets.walletid = wid;
	            x_amount = x_amount - wam;
	         end if;  	
         end loop;         
end;
$$ language plpgsql;



--------------------------------------------------------------------------------------------- testiranje



INSERT INTO Users ( Username, Email, PasswordHash) VALUES
('Marko', 'marko@gmail.com', '1232'),
('Ivan', 'ivan@gmail.com', '1111'),
('Stjepan', 'stjepan@gmail.com','2222');

insert into wallets (userid, amount) values  
('1', 25),
('2', 10),
('2', 5),
('1', 25),
('2', 10),
('2', 5);


insert into books(Title, Author, Price, other)  values          
('Matematička statistika', 'Nikola Sandrića', 30.03, 
   '{"Genre": "Statistika", "Release year": 2020, "Description": "Navodimo osnovne pojmove i rezultate teorije vjerojatnosti koji su velikim dijelom sadrzani u kolegijima Vjerojatnost i Statistika s Preddiplomskog studija matematike na Matematickom odsjeku PMF-a u Zagrebu."}'
),
('Algebarske strukture', 'Boris Širola', 10, 
  '{"Genre": "Algebra", "Release year": 2019, "Description":"Cilj ovog kratkog uvoda je prvo, neformalno, upoznavanje sa pojmovima i objektima koji su predmet proucavanja ovog kolegija, od kojih je centralan pojam algebarske strukture."}'
),
('DIFRAF', 'Ilja Gogić', 16, 
  '{"Genre": "Analiza" , "Release year": 2021, "Description":"Osnovna pitanja matematicke analize realnih funkcija vise varijable su konvergencija nizova, limes funkcije, neprekidnost funkcije, derivabilnost."}'
),
('Uvod u Teoriju brojeva', 'Andrej Dujella', 8, 
  '{"Genre":"Teorija brojeva", "Release year": 2023, "Description":"Teorija brojeva je grana matematike koja se ponajprije bavi proucavanjem svojstava skupa prirodnih brojeva."}'
);

CALL posudba(1,2);   --Nema dovoljno sredstva!
CALL posudba(1,1);   --Sve OK


--select other ->> 'Genre' from books;
--select price from books where other ->> 'Genre' = 'Enciklopedija';

/*drop table books cascade;
drop table transactions cascade;
drop table users cascade;
drop table wallets cascade;*/