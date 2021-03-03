USE SoftUniLec2

--BE AWARE THAT IN JUDGE AFTER AS YOU HAVE TO WRITE BEGIN AND INSTEAD GO WE WRITE END

--1.Employees With Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName 
		FROM Employees
	WHERE Salary > 35000
END


EXEC usp_GetEmployeesSalaryAbove35000

--2.Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Salary decimal(18,4))
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
	WHERE Salary >= @Salary
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@StringInput varchar(max))
AS
BEGIN
	SELECT [Name] AS Town FROM Towns
	WHERE [Name] LIKE @StringInput + '%'
END

EXEC usp_GetTownsStartingWith 'b'

--4. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName varchar(max))
AS
BEGIN
	SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.Name = @TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

--5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel (@salary decimal(18,4))
RETURNS varchar(7)
AS
BEGIN
	DECLARE @salaryLevel varchar(7);

	IF(@salary < 30000)
	BEGIN
		SET	@salaryLevel = 'Low';
	END
	ELSE IF(@salary >= 30000 AND @salary <= 50000 )
	BEGIN
		SET	@salaryLevel = 'Average';
	END
	ELSE IF(@salary > 50000)
	BEGIN
		SET @salaryLevel = 'High';
	END

	RETURN @salaryLevel;
END

SELECT FirstName,
	   LastName, 
	   Salary, 
	   dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
	   FROM Employees

--6. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@levelOfSalary varchar(7))
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END

--7. DefineFunction

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters varchar(max), @word varchar(max))
RETURNS int
AS
BEGIN
	
	DECLARE @counter INT = 1;
	DECLARE @currentLetter CHAR;

		WHILE @counter >= LEN(@word)
			BEGIN
				--take the char from word
				SET @currentLetter = SUBSTRING (@word, @counter, 1) 

				-- check the char in the setOfLetters and give value to @charIndex
				DECLARE @charIndex int = CHARINDEX(@currentLetter, @setOfLetters) 

				--If the char is not in the set the value will be 0
				IF(@charIndex <= 0)
					BEGIN
						RETURN 0
					END

				SET @counter += 1;
			END

RETURN 1
END

SELECT dbo.ufn_IsWordComprised ('bobr','rob')

--8. Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId int)
AS
BEGIN

	--This query delete this employees from EmployeesProjects table
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
						   SELECT EmployeeId FROM Employees
						   WHERE DepartmentID = @departmentId
						)
	--Update all ManagerID to NULL for employees who is gonna be deleted from Employees
	UPDATE Employees 
	SET ManagerID = NULL
	WHERE ManagerID IN (
						   SELECT EmployeeId FROM Employees
						   WHERE DepartmentID = @departmentId
						)

	--Make the ManagerID column Nullable from Deparments
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	--Update all ManagerID to NULL for employees who is gonna be deleted from Departments
	UPDATE Departments 
	SET ManagerID = NULL
	WHERE ManagerID IN (
						   SELECT EmployeeId FROM Employees
						   WHERE DepartmentID = @departmentId
						)

	--DELETE FROM Employees
	DElETE FROM Employees
	WHERE DepartmentID = @departmentId

	--DELETE FROM Departments
	DElETE FROM Departments
	WHERE DepartmentID = @departmentId

	--RETUR THE NUMBER OF Employees from the department which were deleted. The result should be 0
	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId

END

--NEW TABLE
USE Bank
SELECT * FROM AccountHolders
SELECT * FROM Accounts

--9. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [FullName] FROM AccountHolders
END

--10. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@balanceToCheck decimal(18,4)) 
AS
BEGIN
	SELECT ah.FirstName, ah.LastName FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.id = a.AccountHolderid
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @balanceToCheck
	ORDER BY ah.FirstName, ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 100000

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum decimal(18,4), @yearlyInterestRate float, @numberOfYears int)
RETURNS decimal(18,4)
AS
BEGIN
	DECLARE @result decimal(18,4);
	SET @result = ROUND(@sum *(POWER((1+@yearlyInterestRate), @numberOfYears )),4)
RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId int, @interestRate float)
AS
BEGIN

	SELECT TOP(1)
		ah.Id AS [Account id], 
		ah.FirstName, ah.LastName, 
		a.Balance AS[Current Balance] ,
		dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
		FROM AccountHolders AS ah
		JOIN Accounts AS a ON ah.id = a.AccountHolderid
	WHERE AccountHolderID = @AccountId

END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--13. Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames(@gameName nvarchar(50))
RETURNS TABLE
AS
RETURN SELECT(
				SELECT SUM(Cash) AS [SumChash] 
				FROM(	
						SELECT 
								g.Name, 
								ug.Cash, 
								ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS [RowNum]
								FROM Games AS g
								JOIN UsersGames AS ug ON g.Id = ug.GameId
						WHERE g.Name = @gameName

					) AS [RwoNumQuery]
				WHERE [RowNum] % 2 <> 0
			 ) AS [SumChash] 

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

	

