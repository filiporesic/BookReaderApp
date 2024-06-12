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
INSERT INTO BookLocations VALUES 
('1 => ".\\Books\\matstat.pdf"'),
('2 => ".\\Books\\AS.pdf"'),
('3 => ".\\Books\\difraf.pdf"'),
('4 => ".\\Books\\utb.pdf"');

CALL posudba(1,2);   --Nema dovoljno sredstva!
CALL posudba(1,1);   --Sve OK

insert into books(Title, Author, Price, other)  values          
('Uvod u optimizaciju', 'Marko Vrdoljak', 13, 
   '{"Genre": "Optimizacija", "Release year": 2019, "Description": "Zadaci za vježbu."}'
),
('Vremenski nizovi, Hilbertovi prostori', 'Bojan Basrak', 5, 
  '{"Genre": "Vremenski nizovi." , "Release year": 2020 , "Description": "Hilbertovi prostori. Predikcija i uvjetna očekivanja."}'
),
('Kombinatorika', 'Vedran Krčadinac', 26, 
  '{"Genre": "Kombinatorika", "Release year": 2023 , "Description": "Kombinatorika (kombinatorna matematika) je grana diskretne matematike koja se bavi diskretnim strukturama koje su finitne ili koje se mogu brojiti. Povezana je s mnogim drugim granama matematike, poput algebre, teorije vjerojatnosti i geometrije kao i raznim područjima u računarstvu i statističkoj fizici."}'
),
('Markovljevi lanci', 'Rudi Mrazović', 19, 
  '{"Genre": "Statistika", "Release year": 2019, "Description": "U ovom uvodnom poglavlju kratko ćemo ponoviti pojmove nezavisnosti i uvjetne nezavisnosti, te funkcije izvodnice vjerojatnosti. Uvjetna nezavisnost se javlja u definiciji Markovljevih lanaca – intuitivno, to su slučajni procesi u kojima prošlost i budućnost, iako općenito zavisni, postaju uvjetno nezavisni uz danu vrijednost procesa u sadašnjem trenutku. Funkcije izvodnice vjerojatnosti su analitički alat koji ćemo koristiti u analiziranju jednog standardnog primjera Markovljevog lanca, a to su tzv. procesi grananja."}'
),
('Kompleksna analiza', 'Pavle Pandžić', 45, 
  '{"Genre":"Analiza" , "Release year": 2021 , "Description": "Pojam kompleksnih brojeva prvi put susrecemo u srednjoškolskoj matematici kod pronalaženja rješenja kvadratne jednadžbe. Mogli bismo iz toga zakljuciti da su kompleksni brojevi upravo zbog toga i uvedeni (to jest, izmišljeni) - kako bi svaka kvadratna jednadžba imala rješenje. Medutim, povijesno gledajuci, to nije tako bilo, nisu kvadratne jednažbe te koje su motivirale definiranje nove vrste brojeva, nego kubne. Iako nam se to na prvi pogled može ciniti cudno, zapravo je vrlo logicno." }'
),
('INTRAF', 'Ilja Gogić', 60, 
  '{"Genre":"Analiza" , "Release year": 2023 , "Description": "Kao sto znamo, poslije deriviranja na red dolazi integriranje. U R smo integrirali po intervalima ili unijama intervala, dok je u Rn izbor mnogo veci. Najprije cemo integrirati skalarne funkcije f : Rn → R po izvjesnim n-dimenzionalnim podskupovima Rn, pocevsi sa slucajem n = 2. Podrucja integracije u R2 mogu biti pravokutnici, ali i npr. kompaktna podrucja omedena grafovima neprekidnih funkcija."}'
);
INSERT INTO BookLocations VALUES 
('5 => ".\\Books\\uopt_zadaci.pdf"'),
('6 => ".\\Books\\VrNiz.Hilbert.pdf"'),
('7 => ".\\Books\\KOMB.pdf"'),
('8 => ".\\Books\\ML_vjezbe.pdf"'),
('9 => ".\\Books\\KOMPA.pdf"'),
('10 => ".\\Books\\intraf.pdf"');


--select other ->> 'Genre' from books;
--select price from books where other ->> 'Genre' = 'Enciklopedija';

/*drop table books cascade;
drop table transactions cascade;
drop table users cascade;
drop table booklocations cascade;*/