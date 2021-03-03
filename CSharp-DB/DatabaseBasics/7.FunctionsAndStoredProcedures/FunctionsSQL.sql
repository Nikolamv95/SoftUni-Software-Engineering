--CREATE FUNCTION (@variable1, @variable2, etc...)
--RETURNS dataType(int, varchar, etc....)
--AS
--BEGIN
--SOME CODE WITHOUT Insert,Create,Delete operations
--RETURN (@variable between the begin/end code) 
--END


--The data type in RETURNS dataType(int, varchar, etc....) & RETURN (@variable between the begin/end code) should be similar int/int - varchar/varchar

--THEESE IS THE REQUIRED STRUCTURE OF THE FUNCTION

CREATE FUNCTION udf_Pow(@Base int, @Exp int)
RETURNS BIGINT
AS
BEGIN
	DECLARE @PowResult bigint = 1;

		WHILE (@Exp > 0)
		BEGIN
			SET @PowResult = @Base * @PowResult;
			SET @Exp -= 1; --Look here
		END

RETURN @PowResult;
END

--Then we call our custom function with random parameters
SELECT dbo.udf_Pow(2,10) AS CustomFunc, POWER(2,10) AS SystemFunc

--IF we want to update the logic of the FUNCTION we can use CREATE OR ALTER
CREATE OR ALTER FUNCTION udf_Pow(@Base int, @Exp int)
RETURNS BIGINT
AS
BEGIN
	DECLARE @PowResult bigint = 1;

		WHILE (@Exp > 0)
		BEGIN
			SET @PowResult = @Base * @PowResult;
			SET @Exp = @Exp - 1;
		END

RETURN @PowResult;
END


--Example Difference between 2 dates function
CREATE FUNCTION udf_DiffDates(@StartDate datetime2, @EndDate datetime2)
RETURNS int
AS
BEGIN
	DECLARE @Difference int = 0;
		
		IF (@EndDate IS NULL)
		BEGIN
		SET @EndDate = GETDATE();
		END
	
	SET @Difference = DATEDIFF(WEEK, @StartDate, @EndDate) 
RETURN @Difference
END

--OR LIKE IN C#
CREATE OR ALTER FUNCTION udf_DiffDates(@StartDate datetime, @EndDate datetime)
RETURNS int
AS
BEGIN
		IF (@EndDate IS NULL)
		SET @EndDate = GETDATE();
RETURN DATEDIFF(WEEK, @StartDate, @EndDate) 
END

SELECT dbo.udf_DiffDates('2020-01-01', '2020-06-01')
SELECT dbo.udf_DiffDates('2020-01-01', NULL)

--COUNT THE NUMBER OF EMPLOYEES HIRED AT CERTAIN YEAR
--HERE WE CAN SEE THAT WE CAN RETURN THE VALUES FROM A SELECT STATEMENTS
CREATE OR ALTER FUNCTION udf_GetCountEmplByYear(@YearToCheck int)
RETURNS TABLE
AS
RETURN
(
	SELECT *
		FROM [Employees]
			WHERE @YearToCheck = DATEPART(YEAR, dbo.Employees.HireDate)
)

SELECT * FROM dbo.udf_GetCountEmplByYear(2000)


--CREATE FUNCTION with MULTI-STATEMENTS
CREATE OR ALTER FUNCTION udf_Squares(@Count int)
RETURNS @squares TABLE(
 [Id] int PRIMARY KEY IDENTITY,
 [Square] bigint
)
AS
BEGIN
	DECLARE @i int = 1

	WHILE (@i <= @Count)
	BEGIN
		INSERT INTO @squares([Square]) VALUES (@i * @i)
		SET @i = @i + 1;
	END
	RETURN
END

SELECT * FROM dbo.udf_Squares(10) 
--The result is TABLE so we can do additional operations WHILE, ORDER BY, GROUP BY etc....

--LAB1
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel (@Salary money)
RETURNS varchar(MAX)
AS
BEGIN
	DECLARE @Result varchar(MAX)

		IF(@Salary < 30000) 
			SET @Result = 'Low';
		ELSE IF (@Salary > 30000 AND @Salary <= 50000) 
			SET @Result = 'Average';
		ELSE 
			SET @Result = 'High';

	RETURN @Result;
END

SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel FROM Employees