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
    Genre VARCHAR(50) NOT NULL,
    Description VARCHAR(4000) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Wallets (
    WalletId SERIAL PRIMARY KEY,
    UserId INT,
    CurrencyCode CHAR(3) NOT NULL,
    Amount DECIMAL(10, 2),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Transactions (
    TransactionId SERIAL PRIMARY KEY,
    UserId INT,
    BookId INT,
    Title VARCHAR(50) NOT NULL,
    Amount  DECIMAL(10, 2) NOT NULL,
    BorrowDate DATE NOT NULL,
    ReturnDate DATE,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (BookId) REFERENCES Books(BookId)
);

INSERT INTO Users (UserId, Username, Email, PasswordHash) VALUES
('test', 'test@test.com', '1232')