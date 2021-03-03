USE SoftUniLec2

--Structure
--SELECT [DepartmentID](SelectColumns), COUNT(*) AS NumOfEmployees (UseAggregated functions and convert the value to a rows in a table)
	--FROM Employees
	--JOIN add another table to the current one
	--WHERE
	--GROUP BY DepartmentID(column or multiple columns)
	--HAVING
	--ORDER BY NumOfEmployees DESC (sort them by criteria


--Explanation1
--When we group we cant take value which is uniq for every row, Example we want to group by DeparmentID
--we cant select the name of a employee because it`s grouped with other names, so we can take generious values like
--DepartmentID and built-in functions like COUNT, MAX, MIN, AVG and so on
SELECT [DepartmentID] 
	FROM Employees
	GROUP BY DepartmentID

--We can make operations which takes specific values from the group and use Aggregated functions over them
SELECT [DepartmentID], MIN(Salary) 
	FROM Employees
	GROUP BY DepartmentID


SELECT [FirstName], AVG(Salary)
	FROM Employees
	GROUP BY [FirstName]

--Explanation2
--When we group by multiple groups every row should contains combination between DepID and FirstName
--For example we have row with DepID = 7 and FirstName Andrew which means taht in this Dep we have 2 people with name Andrew
SELECT [DepartmentID], FirstName, COUNT(*) AS NumOfEmployees
	FROM Employees
	GROUP BY DepartmentID, FirstName

--Explanation3
--In this example is shown that we cant take directly the first name from the group but we can take it and do aggregated function over them which will return is all the first names in the group spretted by space
SELECT [DepartmentID], STRING_AGG(FirstName, ' ') AS TeamNames
	FROM Employees
	GROUP BY DepartmentID

--Explanation4
SELECT [DepartmentID], FirstName, COUNT(Salary) AS NumOfEmployees
	FROM Employees
	GROUP BY DepartmentID, FirstName

SELECT [DepartmentID], FirstName, COUNT(*) AS NumOfEmployees
	FROM Employees
	GROUP BY DepartmentID, FirstName

--COUNT(*) returns the absolute value with the empy cells ()

--Example5
SELECT [DepartmentID], FirstName, COUNT(*) AS NumOfEmployees
	FROM Employees
	WHERE Salary > 10000
	GROUP BY DepartmentID
	--HAVING - we can use having after the returned value of the query until group by. We cant use WHERE 2 times, this is why we use HAVING


--SELECT all the employees with salary over 10 000 and NumOfEmployees more or equals to 10
SELECT [DepartmentID], COUNT(*) AS NumOfEmployees
	FROM Employees
	WHERE Salary > 10000
	GROUP BY DepartmentID
	HAVING COUNT(*) >= 10
