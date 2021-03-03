SELECT * FROM WizzardDeposits 

--Exc1
SELECT COUNT(*) AS [Count] FROM WizzardDeposits 

--Exc2
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits 

--Exc3
SELECT wd.DepositGroup, 
	   MAX(wd.MagicWandSize) AS LongestMagicWand 
  FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

--Exc4
SELECT TOP(2) wd.DepositGroup
  FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup
ORDER BY AVG(wd.MagicWandSize) ASC

--OR
SELECT TOP (2) DepositGroup 
FROM (
		SELECT DepositGroup, AVG(MagicWandSize) AS [AverageWandSize]
		FROM WizzardDeposits
		GROUP BY DepositGroup
		) AS [AverageWandSizeQuery]
ORDER BY [AverageWandSize]

--Exc5
SELECT wd.DepositGroup, 
	   SUM(wd.DepositAmount) AS TotalSum 
  FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

--Exc6
SELECT wd.DepositGroup, 
	   SUM(wd.DepositAmount) AS TotalSum 
  FROM WizzardDeposits AS wd
  WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup

--Exc7
SELECT wd.DepositGroup, 
	   SUM(wd.DepositAmount) AS TotalSum 
  FROM WizzardDeposits AS wd
  WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup
HAVING SUM(wd.DepositAmount) < 150000
ORDER BY TotalSum DESC

--Exc8
SELECT wd.DepositGroup, wd.MagicWandCreator, MIN(wd.DepositCharge) FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup, wd.MagicWandCreator
ORDER BY wd.MagicWandCreator, wd.DepositGroup

--Exc9 - NOT RESOLVED
SELECT AgeGroup, COUNT(*) AS [WizardCount] 
FROM
	(SELECT *,
		CASE 
			WHEN Age <= 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup
FROM WizzardDeposits) AS [AgeGroupQuery]
GROUP BY [AgeGroup]


--Exc10
SELECT [FirstLetter] 
FROM
	(SELECT LEFT(wd.FirstName,1) AS [FirstLetter] 
		FROM WizzardDeposits AS wd
			WHERE wd.DepositGroup = 'Troll Chest') AS [LetterTableQuery]
GROUP BY [FirstLetter]
ORDER BY [FirstLetter]

 --Exc11
SELECT 
	wd.DepositGroup,
	wd.IsDepositExpired,
	AVG(wd.DepositInterest) AS [AverageInterest]
FROM WizzardDeposits AS wd
WHERE wd.DepositExpirationDate > '1985-01-01'
GROUP BY wd.DepositGroup
ORDER BY wd.DepositGroup DESC, wd.IsDepositExpired ASC

--Exc12
SELECT SUM([Difference]) AS SumDifference 
FROM
	(SELECT 
		wd.FirstName AS [HostWizard],
		wd.DepositAmount, 
		LEAD(FirstName) OVER (ORDER BY Id ASC) AS [Guest Wizard],
		LEAD(wd.DepositAmount) OVER (ORDER BY Id ASC) AS [Guest Wizard Deposit],
		wd.DepositAmount - LEAD(wd.DepositAmount) OVER (ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits AS wd) AS [DiffQuery]

--OR
SELECT SUM ([Difference]) AS [SumDifference] 
FROM (SELECT 
		w.DepositAmount - (
			SELECT c.DepositAmount 
				FROM WizzardDeposits AS c 
					WHERE c.Id = w.Id + 1) AS [Difference]
	FROM WizzardDeposits AS w) AS wd

--Exc13
SELECT DepartmentID, 
	   SUM(Salary) AS [TotalSalary] 
	FROM Employees
GROUP BY DepartmentID

--Exc14
SELECT e.DepartmentID, 
	   MIN(e.Salary) AS [MinimumSalary] 
	FROM Employees AS e
WHERE e.HireDate > '2000-01-01' AND e.DepartmentID IN (2,5,7)
GROUP BY e.DepartmentID

--Exc15
--1
SELECT * INTO EmployeesWithOverSalaries FROM Employees
WHERE Salary > 30000
--2
DELETE FROM EmployeesWithOverSalaries WHERE ManagerID = 42
--3
UPDATE EmployeesWithOverSalaries
SET Salary += 5000
WHERE DepartmentID = 1
--4
SELECT DepartmentID, AVG(Salary) AS [AverageSalary]
	FROM EmployeesWithOverSalaries
GROUP BY DepartmentID

--Exc16
SELECT DepartmentID, [MaxSalary] 
FROM (
	SELECT DepartmentID, 
		   MAX(Salary) AS [MaxSalary] 
	FROM Employees
	GROUP BY DepartmentID) AS [MaxSalaryQuery]
WHERE [MaxSalary] NOT BETWEEN 30000 AND 70000

--Exc17
SELECT COUNT(*) AS [Count] FROM Employees
WHERE ManagerID IS NULL

--Exc18
SELECT DepartmentID, Salary AS [ThirdHighestSalary] 
	FROM (SELECT e.DepartmentID, 
			     e.Salary,
				 DENSE_RANK() OVER (PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS [Dense Rank]  
			FROM Employees AS e
			GROUP BY DepartmentID, Salary) AS [SalaryRankingQuery]
WHERE [Dense Rank] = 3

--OR
SELECT DISTINCT DepartmentID, 
				Salary AS [ThirdHighestSalary] 
	FROM (SELECT e.DepartmentID, 
			     e.Salary,
				 DENSE_RANK() OVER (PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS [Dense Rank]  
			FROM Employees AS e) AS [SalaryRankingQuery]
WHERE [Dense Rank] = 3

--Exc19
SELECT TOP(10) e1.FirstName, 
	   e1.LastName, 
	   e1.DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (
					SELECT AVG(e2.Salary) AS [AverageSalary]
				    FROM Employees AS e2
					WHERE e2.DepartmentID = e1.DepartmentID
				    GROUP BY e2.DepartmentID
				   )
ORDER BY e1.DepartmentID ASC

 