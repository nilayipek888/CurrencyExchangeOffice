-- Database schema prepared for future project extension

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE CurrencyBalances (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    CurrencyCode NVARCHAR(3) NOT NULL,
    Balance DECIMAL(18,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    CurrencyCode NVARCHAR(3) NOT NULL,
    TransactionType NVARCHAR(10) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    ExchangeRate DECIMAL(18,4) NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
