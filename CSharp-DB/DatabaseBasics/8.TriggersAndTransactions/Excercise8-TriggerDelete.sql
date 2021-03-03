CREATE TABLE Deleted_Employees
(
	EmployeeId int PRIMARY KEY,
	FirstName varchar(30),
	LastName varchar(30),
	MiddleName varchar(30),
	JobTitle varchar(30),
	DepartmentId int ,
	Salary decimal(18,4)
)

CREATE TRIGGER tr_DeletedEmployees ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	     SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary 
	       FROM deleted AS d
END