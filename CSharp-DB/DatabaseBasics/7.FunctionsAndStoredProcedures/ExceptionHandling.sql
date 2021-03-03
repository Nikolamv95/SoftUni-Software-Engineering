--Throw Exception
CREATE OR ALTER PROCEDURE sp_GetEmployeesByExperience8 (@Year int)
AS
	IF(@Year < 0)
		THROW 50001, 'The year should be positive number', 1;
	SELECT * 
	FROM Employees 
	WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @Year
GO

EXEC sp_GetEmployeesByExperience8 10

--TRY CATCH BLOCK
BEGIN TRY
	-- Generate some code
	SELECT 1/0
END TRY
BEGIN CATCH
	SELECT
		 ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage;
END CATCH
GO

--EXAMPLE1
CREATE PROCEDURE sp_InsertEmployeeForProject(@EmployeeId int, @ProjectId int)
AS
	DECLARE @ProjectsCount int;
	SET @ProjectsCount = (
		SELECT COUNT(*) 
		FROM [EmployeesProjects]
		WHERE EmployeeID = @EmployeeId);
	
	IF(@ProjectsCount >= 3)
		THROW 50001, 'Employee already has 3 or more projects', 1;
	
	INSERT INTO dbo.EmployeesProjects (EmployeeID, ProjectID) 
		VALUES (@EmployeeId, @ProjectId);
GO

EXEC sp_InsertEmployeeForProject 2, 1

SELECT * FROM [EmployeesProjects] WHERE EmployeeID = 2