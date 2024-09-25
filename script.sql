CREATE TABLE Accounts (
    Id TEXT NOT NULL CONSTRAINT "PK_Accounts" PRIMARY KEY,
    Name TEXT NOT NULL
);

 CREATE TABLE Transactions (
    Id TEXT NOT NULL CONSTRAINT "PK_Transactions" PRIMARY KEY,
    AccountId TEXT NOT NULL,
    Amount TEXT NOT NULL,
    Description TEXT NOT NULL,
    Date TEXT NOT NULL,
    Income INTEGER NOT NULL,
    CONSTRAINT "FK_Transactions_Accounts_AccountId" FOREIGN KEY ("AccountId") REFERENCES "Accounts" ("Id") ON DELETE CASCADE
);