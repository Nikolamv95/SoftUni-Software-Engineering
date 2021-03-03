--Lecture Joins

--This type of Join is INNER JOIN and it will return a value only if the condition afte ON is covered
--for example if we have and TownID on both tables null it will skip the valu from the result
SELECT * FROM Addresses AS a
	JOIN Towns AS t ON a.TownID = t.TownID

--The next Example is LEFT JOIN it will return all the values after ON even if their values are NULL or dont have connection with the RIGHT TABEL
SELECT * FROM Addresses AS a
	LEFT JOIN Towns AS t ON a.TownID = t.TownID

--The next Example is RIGHT Join which will return all the values which covored the condition after ON + the values which dont have connection with the LEFT TABEL
SELECT * FROM Addresses AS a
	RIGHT JOIN Towns AS t ON a.TownID = t.TownID

--The next Example is FULL OUTER JOIN which will return all the values which covored the condition afet ON + all the values which dont have connection to the RIGHT TABLE (LEFT JOIN) + the values which dont have connection to the LEFT TABEL (RIGHT JOIN)
SELECT * FROM Addresses AS a
	FULL OUTER JOIN Towns AS t ON a.TownID = t.TownID

--The next Example is CROSS JOIN. It will mix all the data in the table 1 value from table 1 with all values from table 2 and so on
--There is no need for a ON condition
SELECT * FROM Addresses AS a
	CROSS JOIN Towns AS t 
--Its similar to:
SELECT * FROM Addresses, Towns

--We can add more conditions afte ON
SELECT * FROM Addresses AS a
	JOIN Towns AS t ON a.TownID = t.TownID --AND --something else

-- We can JOIN Multiple tables next each other. At this time we have 3 tables next each other
SELECT * FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t ON a.TownID = t.TownID 

--LAB JOIN

--Lab1
SELECT TOP (50) 
	e.FirstName, 
	e.LastName, 
	t.Name AS Town, 
	a.AddressText 
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Lab2
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Lab3
SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE ([HireDate] > '1999-01-01') AND (d.Name IN('Sales', 'Finance'))
ORDER BY HireDate

--Lab4
--The key thing here is the primary key from EmployeeID to be equals to the ManagarID
SELECT TOP(50)
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees AS e
	LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID

--WHEN WE HAVE MANY TO MANY RELATIONSHIP THE MAIN TABLE BEFORE THE JOINS SHOULD BE THE MIDDLE TABLE
--THIS IS THE TABLE WHICH HOLDS BOTH PRIMARIY KEYS FROM THE TABLES
SELECT e.FirstName, e.LastName, p.Name
	FROM EmployeesProjects AS ep
	LEFT JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID




