CREATE TABLE dbo.Pledge (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(100) NULL,
    Email varchar(150) NULL,
    ZipCode varchar(10) NOT NULL,
    NonProfit int NULL,
    SmallBiz int NULL
);
