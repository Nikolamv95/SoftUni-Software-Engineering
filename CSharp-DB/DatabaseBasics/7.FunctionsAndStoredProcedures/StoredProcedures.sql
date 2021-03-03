--Create stored procedures



--BE AWARE THAT IN JUDGE AFTER AS YOU HAVE TO WRITE BEGIN AND INSTEAD GO WE WRITE END



--ONE STORED PROCEDURE CAN RETURN MULTIPLE RESULTS OR SINGLE RESULT. WITH THIS PROCEDURE WE CAN CREATE, REMOVE, UPDATE, INSERT DATA INTO CURRENT TABLES AND WE CAN CREATE PROCEDURES WHICH MAKE DIFFERENT TYPE OF OPERATIONS. REFFERENCE TO C# CREATE CUSTOM FUNCTIONS/METHODS


--EXAMPLE 1
--The logic is similar to the functions but here we can write INSERT, UPDATE, DELETE statements in the scope of the stored procedure AS -> GO
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience
AS
	SELECT * 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > 19
GO

--We execute the stored procedure with EXEC
EXEC sp_GetEmployeesByExperience



--EXAMPLE 2
--We can make this function to work dynamicly
--we also can give default parameter which later can be changed when we call the procedure
--CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience2 (@Year int = NULL)
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience2 (@Year int)
AS
	SELECT * 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year
GO

EXEC sp_GetEmployeesByExperience2 19




--EXAMPLE 3
--We can work also with multyple variables
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience3 (@Year int, @MinSalary money = 10000)
AS
	SELECT * 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year AND Salary > @MinSalary
GO

EXEC sp_GetEmployeesByExperience3 19, 25000 --OR another Syntax EXEC sp_GetEmployeesByExperience3 @Year = 19, @MinSalary = 25000




--EXAMPLE 4
--We can put multiple selects inside
--We can work also with multyple variables
--This procedure can return multiple results
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience4 (@Year int, @MinSalary money = 10000)
AS
	SELECT * 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year AND Salary > @MinSalary

	SELECT * FROM Addresses
GO

EXEC sp_GetEmployeesByExperience4 19, 25000 --OR another Syntax EXEC sp_GetEmployeesByExperience3 @Year = 19, @MinSalary = 25000




--EXAMPLE 5
--We can return result with the procedure
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience5 (@Count int OUTPUT, @Year int = 19, @MinSalary money = 12000)
AS
	SET @Count = (SELECT COUNT (*) 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year AND Salary > @MinSalary)
GO

DECLARE @Count int;
EXEC sp_GetEmployeesByExperience5 @Count OUTPUT
SELECT @Count


--EXAMPLE 6
--Another example which returns single result
CREATE PROCEDURE dbo.usp_AddNumbers
	@firstNumber SMALLINT,
	@secondNumber SMALLINT,
	@result INT OUTPUT
AS
SET @result = @firstNumber + @secondNumber
GO

DECLARE @answer smallint
EXECUTE usp_AddNumbers 5, 6, @answer OUTPUT
SELECT 'The result is: ', @answer




--EXAMPLE 7
--Another example which returns multiple result
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience6 (@Count int OUTPUT, @CountEmployees int OUTPUT, @Year int = 19, @MinSalary money = 12000)
AS
	SET @Count = (SELECT COUNT (*) 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year AND Salary > @MinSalary)

	SET @CountEmployees = (SELECT COUNT(*) FROM Employees)
GO

DECLARE @Count int;
DECLARE @CountEmployees int;
EXEC sp_GetEmployeesByExperience6 @Count OUTPUT, @CountEmployees OUTPUT;
SELECT @Count, @CountEmployees






--This procedure show us what are the dependancies of the function, table or other procedure
--we are giving the value in 'VALUE' -> this type of brackets '' 
EXEC sp_depends 'udf_GetCountEmplByYear'
EXEC sp_depends 'dbo.Employees'

--This function give us the metadata(like reflection) of the table
EXEC sp_columns 'Employees'