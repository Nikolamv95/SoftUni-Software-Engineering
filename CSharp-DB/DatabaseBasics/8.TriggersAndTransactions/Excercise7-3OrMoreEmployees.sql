--Create a procedure usp_AssignProject(@emloyeeId, @projectID) that assigns projects to employee. 
--If the employee has more than 3 project throw exception and rollback the changes. 
--The exception message must be: "The employee has too many projects!" with Severity = 16, State = 1.

CREATE PROC usp_AssignProject(@emloyeeId int, @projectID int)
AS
BEGIN TRANSACTION

DECLARE @numOfProcets int = (SELECT COUNT(*) FROM Employees AS e
							JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
							WHERE e.EmployeeID = @emloyeeId)

	IF(@numOfProcets >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END

INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
VALUES (@emloyeeId, @projectID)

COMMIT

SELECT * FROM EmployeesProjects
EXEC usp_AssignProject 2, 10

