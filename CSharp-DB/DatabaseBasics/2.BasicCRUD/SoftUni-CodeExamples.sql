--START
--Table departments take the value d, and with d.(name of the column) you can select the column which you want
--you can use AS to rename your selected Columns example d.Name AS(rename to) DepartmentName
SELECT d.Name AS DepartmentsName FROM Departments AS d
-- both examples are similar
SELECT [Name] AS DepartmentsName FROM Departments
--En=ND

--START
--This is how we concatenate 2 string columns
SELECT FirstName, LastName 
	FROM Employees  

SELECT FirstName + ' ' + LastName AS [FullName]
	FROM Employees  

SELECT FirstName + 'Mr''' + LastName AS [FullName]
	FROM Employees  
--END

--START
--We can select more than one colum
SELECT FirstName + ' ' + LastName 
	AS [FullName], JobTitle, Salary
		FROM Employees  
--END

--START
--With DISTINCT we select only unique data with no repeate values
SELECT DepartmentID
		FROM Employees

-- No repeates
SELECT DISTINCT DepartmentID
		FROM Employees
--END

--START
--WHERE filters the data which we want to work with
SELECT *
	FROM Employees
		WHERE DepartmentID = 7

--We use AND to filter by 2+ criteria
SELECT *
	FROM Employees
		WHERE DepartmentID = 7 AND Salary <= 50000
--Between takes the low border 30 000 and highest order 80 000
SELECT *
	FROM Employees
		WHERE Salary BETWEEN 30000 AND 80000

--We use not to NOT select these values
SELECT *
	FROM Employees
		WHERE NOT Salary BETWEEN 30000 AND 80000

--We use in when we want to select (1,2,3,4,5) values which are one after another
--The logic is similar with NOT IN we will not select this value
SELECT *
	FROM Employees
		WHERE DepartmentID IN (1,2,3)	

--This <> means like != in C#
SELECT *
	FROM Employees
		WHERE DepartmentID <> 7
--END

--We can SELECT NULL Values
SELECT *
	FROM Employees
		WHERE MiddleName IS NULL
--START
--We use ORDER BY for sorting
SELECT *
	FROM Employees
WHERE DepartmentID IN (1,2,3)
ORDER BY Salary DESC -- DESC is for Decreasing ASC is for Increasing

--Multiple sorting
SELECT *
	FROM Employees
WHERE DepartmentID IN (1,2,3)
ORDER BY Salary DESC, ManagerID ASC
--END

--START
--With TOP 5 we take the top 5 values
SELECT TOP(5)*
	FROM Employees
ORDER BY Salary --ASC or DESC
--END

--START
--How to create view which you can access easly
CREATE VIEW v_EmoployeesSalary AS
SELECT FirstName + ' ' + LastName AS [FullName], Salary
	FROM Employees  

SELECT * FROM v_EmoployeesSalary
--END

--START
--This is how we insert data into the table. Always the number of the columns and the data values which we input
--should be similar - 4 rows - 4 input values 
SELECT * FROM Towns

INSERT INTO Towns 
Values('Berlin')
--END

--START
--BULK Insert
SET IDENTITY_INSERT Towns OFF
INSERT INTO Towns Values
('Varna'),
('Burgas')

SELECT * FROM Towns
--END

--START
--This is how we take data from one table and insert it into another table
-- We take only the required values from Departments
--and insert the into Projcets tabel
INSERT INTO Projects ([Name], StartDate) 
	SELECT [Name], GETDATE()
		FROM Departments;

SELECT * FROM Projects
--END

--START
--If we dont have such a table SQL will create it for us
SELECT FirstName, LastName, JobTitle
	INTO MyTopEmployees
	FROM Employees;

SELECT * FROM MyTopEmployees;
--END

--START
--This is how we create sequence which we save in a VIEW
CREATE SEQUENCE sq_IncreaseWith10
	AS INT
 START WITH 10
 INCREMENT BY 5
 MINVALUE 5
 MAXVALUE 50
  CYCLE

SELECT NEXT VALUE FOR sq_IncreaseWith10
--END

--START
--This is how we update values in a column from a table
UPDATE Addresses
SET TownID = NULL
WHERE TownID = 1

SELECT * FROM Addresses
WHERE TownID = 1
--END

--START
--This is how we truncate a table if it doesnt have relations with other tables
TRUNCATE TABLE Towns --Dont execute
--END

--START
--CHECK CONSTRAINT this is like a rule if x is not y dont create
SELECT * FROM Employees
ALTER TABLE Employees
ADD CONSTRAINT CS_NameLengthNew CHECK(LEN(FirstName) > 1)
--END

--START
--THIS IS CASE Construnction which allowes us to check if a value is equal to certain conditions
--and if true then we do something if false(Else) then do something, and at the end with END AS
--we will create new column with the result
SELECT CountryName, CountryCode,
	CASE
	WHEN CurrencyCOde = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END AS [Currency]
FROM Countries
ORDER BY CountryName
--END