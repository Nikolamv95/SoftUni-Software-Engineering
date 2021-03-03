SELECT * FROM Employees

--Ex1
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Sa%'

--Ex2
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--Ex3
SELECT FirstName FROM Employees
WHERE DepartmentID in(3,10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--Ex4
SELECT FirstName, LastName FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'

--Ex5
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN(5, 6)
ORDER BY [Name]

--Ex6
SELECT [Name] FROM Towns
WHERE LEFT([Name], 1) IN ('M','K','B','E')
ORDER BY [Name] ASC

--Ex7
SELECT * FROM Towns
WHERE LEFT([Name],1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

--Ex8
CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate ) > 2000

SELECT * FROM v_Employees_Hired_After

--Ex9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

--Ex10
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE (Salary BETWEEN 10000 AND 50000)
ORDER BY Salary DESC

--Ex11
SELECT * FROM
(SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() 
	OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE (Salary BETWEEN 10000 AND 50000)) AS TempTable
WHERE [Rank] = 2
ORDER BY Salary DESC 

--Ex12
SELECT 
CountryName AS [Country Name], 
IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY [ISO Code]

--Ex13
SELECT 
p.PeakName, 
r.RiverName,
LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName)-1)) AS Mix
	FROM Peaks AS p, Rivers AS r 
WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY Mix ASC

--Ex14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

--Ex15
SELECT Username,
	SUBSTRING(Email, CHARINDEX('@', Email) +1, LEN(Email)) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username

--Ex16
SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username ASC

--Ex17
SELECT [Name],
	CASE 
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration >= 7 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY [Name], Duration

--Ex18
SELECT ProductName, OrderDate,
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

--Ex19
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Birthdate DATETIME NOT NULL
)

INSERT INTO People ([Name], Birthdate)
VALUES
		('Victor', '2000-12-07'),
        ('Steven', '1992-09-10'),
	    ('Stephen', '1910-09-19'),
	    ('John', '2010-01-06')

SELECT 
[Name],
DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People

