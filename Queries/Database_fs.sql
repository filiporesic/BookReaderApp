--------------------------------------------------------------------------------------------- baza

CREATE TABLE Users (
    UserId SERIAL PRIMARY KEY,
    Username VARCHAR(20) NOT NULL UNIQUE,
    Wallet DECIMAL(10, 2) CHECK ( wallet >= 0 ) default 0,
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



CREATE TABLE Transactions (
    TransactionId SERIAL PRIMARY KEY,
    UserId INT,
    BookId INT,
    Amount  DECIMAL(10, 2) NOT NULL CHECK ( amount >= 0 ),
    BorrowDate DATE  NOT NULL,
    ReturnDate DATE ,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);


CREATE EXTENSION HSTORE;
CREATE TABLE BookLocations (BookLocation hstore);
CREATE INDEX idx_BookLocations ON booklocations USING GiST(BookLocation);

INSERT INTO BookLocations VALUES 
('1 => ".\\Books\\matstat.pdf"'),
('2 => ".\\Books\\AS.pdf"'),
('3 => ".\\Books\\difraf.pdf"'),
('4 => ".\\Books\\utb.pdf"');




--------------------------------------------------------------------------------------------- funkcije




-- NAPLATA POSUDBE

create or replace function wallet_check () returns trigger as $$
begin 
	  if( new.amount > 
	       ( select wallet from users 
	                            where users.userid = new.userid) )  then  
	           raise exception 'Korisnik nema dovoljno sredstva u novčaniku!';
	  end if;
	 
	  return new;
end;
$$ language plpgsql;





create trigger check_buy 
  before insert on transactions
  for each row 
     execute function wallet_check();
    
    
     
    
create or replace procedure posudba (   --ako ne postoje userid ili bookid isto provjeravamo!
       x_bookid INT,
       x_userid INT) AS $$
declare 
    x_amount decimal(10,2);
    wllt      decimal(10,2);
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
    
    select wallet 
        into wllt 
        from users
        where userid = x_userid;
       
	 update users set wallet = wallet - x_amount 
	              where users.userid = x_userid;
end;
$$ language plpgsql;



--------------------------------------------------------------------------------------------- testiranje


INSERT INTO Users ( Username, Email, Wallet , PasswordHash) VALUES
('Marko', 'marko@gmail.com', 50,  '1232'),
('Ivan', 'ivan@gmail.com', 30 ,  '1111'),
('Stjepan', 'stjepan@gmail.com', 20 , '2222');


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
drop table booklocations cascade;*/