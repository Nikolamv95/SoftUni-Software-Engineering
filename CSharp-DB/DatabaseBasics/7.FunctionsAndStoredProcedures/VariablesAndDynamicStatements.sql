--Declairing and Operations with Variables

--Step1 -> Creating Variable
--KEYWORD -> Declare, after that @(name of the variable), type of date, = value
--This is the right syntax how we create variables
DECLARE @Year2 smallint = 2021;
DECLARE @Year smallint = 1999;

--With SET we can change the value of the variable
SET @Year = 2020

--With SELECT we call the value of the variabel. BE AWARE THAT THE VAIRABLE COULD BE A TABLE not single value 
SELECT @Year2 AS [Year], @Year2 AS [YearTwo]

--This is how we can execute statements with variables dynamically.
--@Table keeps the data of the Employees table and with the -> String operation -> 'SELECT COUNT(*) FROM '
--we can access the data inside, and do operations with them
DECLARE @TableName nvarchar(9) = 'Employees';

EXEC('SELECT COUNT(*) FROM ' + @TableName) -- Result -> 293
SELECT COUNT(*) FROM Employees -- Result -> 293

EXEC('SELECT SUM(Salary) FROM ' + @TableName) -- Result -> 5421900.00
SELECT SUM(Salary) FROM Employees -- Result -> 5421900.00


