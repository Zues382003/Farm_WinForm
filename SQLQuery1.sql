CREATE DATABASE FarmDB;

USE FarmDB;

CREATE TABLE Animals
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    Quantity INT,
);

select * from Animals;