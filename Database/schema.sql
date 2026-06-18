-- Currency Exchange Office database schema
-- SQL Server version

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE CurrencyBalances (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    CurrencyCode NVARCHAR(3) NOT NULL,
    Balance DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_CurrencyBalances_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT UQ_CurrencyBalances_User_Currency UNIQUE (UserId, CurrencyCode)
);

CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NULL,
    CurrencyCode NVARCHAR(3) NOT NULL,
    TransactionType NVARCHAR(10) NOT NULL,
    InputAmount DECIMAL(18,2) NOT NULL,
    OutputAmount DECIMAL(18,2) NOT NULL,
    ExchangeRate DECIMAL(18,4) NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Transactions_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);

INSERT INTO Users (FullName, Email)
VALUES ('Demo User', 'demo@example.com');

INSERT INTO CurrencyBalances (UserId, CurrencyCode, Balance)
VALUES (1, 'PLN', 10000.00);
