--Subqueries are nested queries
--We can create a view with the querie which we need and then to call him in another querie 
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE ([HireDate] > '1999-01-01') AND e.DepartmentID 
	IN (SELECT DepartmentID FROM Departments WHERE d.Name LIKE 'E%')
ORDER BY HireDate

--Lab1
SELECT *,
(SELECT AVG(Salary) FROM Employees AS e WHERE e.DepartmentID = d.DepartmentID) 
	AS AverageSalary
	FROM Departments AS d
WHERE (SELECT COUNT(*) FROM Employees AS en WHERE en.DepartmentID = d.DepartmentID ) > 0
ORDER BY AverageSalary

--Variation2
SELECT 
DepartmentID, 
COUNT(*) AS NumOfEmp, 
AVG(Salary) AS AverageSalary FROM Employees
GROUP BY DepartmentID
ORDER BY AverageSalary

--We can create temporary table with CREATE TABLE #TempTable (add data types)