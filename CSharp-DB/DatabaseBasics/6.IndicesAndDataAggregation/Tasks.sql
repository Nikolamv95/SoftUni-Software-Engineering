--Task1
SELECT DepartmentID, SUM(Salary) AS SumSalaries
	FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID ASC

--Task2
SELECT 
	e.DepartmentID, 
	SUM(e.Salary) AS TotalSalaries
	FROM Employees AS e
GROUP BY e.DepartmentID
HAVING SUM(e.Salary) >= 15000

--Task3
SELECT 
	e.DepartmentID, 
	COUNT(*),
	AVG(Salary) AS AvgSalary
	FROM Employees AS e
GROUP BY e.DepartmentID
HAVING AVG(e.Salary) < 15000 AND COUNT(*) < 10
ORDER BY AvgSalary ASC