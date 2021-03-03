--Exc1
SELECT TOP (5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--Exc2
SELECT TOP(50) 
e.FirstName, 
e.LastName, 
t.Name AS Town, 
a.AddressText 
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName

--Exc3
SELECT 
e.EmployeeID,
e.FirstName, 
e.LastName, 
d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID ASC

--Exc4
SELECT TOP(5)
e.EmployeeID,
e.FirstName, 
e.Salary,
d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID ASC

--Exc5
SELECT TOP(3)
e.EmployeeID,
e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID	IS NULL
ORDER BY e.EmployeeID ASC

SELECT TOP(3)
e.EmployeeID,
e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

--Exc6
SELECT
e.FirstName,
e.LastName,
e.HireDate,
d.Name AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales','Finance') AND (e.HireDate	> '1999-01-01')
ORDER BY e.HireDate ASC

--Exc7
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName 
	FROM EmployeesProjects AS ep
	JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE (p.StartDate > '2002-08-13') AND (p.EndDate IS NULL)
ORDER BY e.EmployeeID

--Exc8
SELECT e.EmployeeID, e.FirstName,
	CASE
		WHEN DATEPART(YEAR,p.StartDate ) >= 2005 THEN NULL
		ELSE p.Name
	END AS [ProjectName]
FROM EmployeesProjects AS ep
JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--Exc9
SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID ASC

--Exc10
SELECT TOP(50) 
e.EmployeeID, 
e.FirstName + ' ' + e.LastName AS [EmployeeName], 
em.FirstName + ' ' + em.LastName AS [ManagerName], 
d.Name AS [DepartmentName]
	FROM Employees AS e
	LEFT JOIN Employees AS em ON e.ManagerID = em.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC

--Exc11
SELECT MIN(MinAverageSalary) AS MinAverageSalary
FROM (SELECT AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY(d.Name)) AS t;

--Exc12
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM MountainsCountries AS mc
JOIN Peaks AS p ON mc.MountainId = p.MountainId
JOIN Mountains AS m ON p.MountainId = m.Id
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--Exc13
SELECT mc.CountryCode, COUNT(mc.MountainId ) AS MountainRanges FROM MountainsCountries AS mc
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode

--Exc14
SELECT TOP(5) c.CountryName, r.RiverName FROM CountriesRivers AS cr
RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

--Exc15
SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM
(
	SELECT ContinentCode, CurrencyCode, CurrencyUsage,
		DENSE_RANK()
		OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS [Rank]
	FROM
	(
		SELECT ContinentCode, CurrencyCode, Count(CurrencyCode) AS CurrencyUsage
		FROM Countries
		GROUP BY CurrencyCode, ContinentCode
	) AS CurrencyUsage
) AS CurrencyRankings
WHERE[RANK] = 1 AND CurrencyUsage > 1
ORDER BY ContinentCode

--Exc16
SELECT COUNT(*) AS [Count] 
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

--Exc17
--Table Peaks
CREATE VIEW [Highest Peak BY Country] AS
SELECT CountryName, HighestPeakElevation
FROM
(
	SELECT c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation]  FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	GROUP BY c.CountryName
) AS [HighestPeakElevation]
ORDER BY HighestPeakElevation DESC

--Table Rivers
CREATE VIEW [Longest River BY Country] AS
SELECT CountryName, LongestRiverLength
FROM
(
	SELECT c.CountryName, MAX(r.Length) AS [LongestRiverLength] FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
) AS [LongestRiverLength]
ORDER BY LongestRiverLength DESC

--Combine both tables
SELECT TOP(5) hpc.CountryName, hpc.HighestPeakElevation, lrc.LongestRiverLength
	FROM [Highest Peak BY Country] AS hpc
	LEFT JOIN [Longest River BY Country] AS lrc ON hpc.CountryName	= lrc.CountryName
ORDER BY hpc.HighestPeakElevation DESC, lrc.LongestRiverLength DESC, hpc.CountryName ASC

--Solution 2
SELECT 
	c.CountryName, 
	MAX(p.Elevation) AS [HighestPeakElevation], 
	MAX(r.Length) AS [LongestRiverLength]  
FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY (c.CountryName)
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName ASC

--Exc18
SELECT TOP(5) Country, 
	   CASE 
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
	   END AS [Highest Peak Name],
	   CASE 
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
	   END AS [Highest Peak Elevation], 
	   CASE 
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
	   END AS [Mountain]
FROM 
	(SELECT *,
		DENSE_RANK() OVER
		(PARTITION BY [Country] ORDER BY Elevation DESC) AS [PeakRank]
		FROM
			(
			SELECT c.CountryName AS [Country],
			   p.PeakName,
			   p.Elevation,
			   m.MountainRange
			FROM Countries AS c
				LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
				LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
				LEFT JOIN Peaks AS p ON m.Id = p.MountainId
			) AS [FullInfoQuery]
	) AS [PeakRankingsQuery]
WHERE [PeakRank] = 1
ORDER BY Country ASC, [Highest Peak Name] ASC






 
