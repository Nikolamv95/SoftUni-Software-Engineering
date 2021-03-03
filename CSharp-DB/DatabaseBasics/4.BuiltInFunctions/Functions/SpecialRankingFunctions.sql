--START
--CAST & CONVERT – conversion between data types
--SELECT CAST(DATA AS NewType)
--END

--START
--ISNULL – swaps NULL values with a specified default value
--IF value is null set as new value
--ISNULL(Value, NewValue)
--END

--START
--OFFSET & FETCH – get only specific rows from the result set
SELECT * FROM Projects
ORDER BY [StartDate]
OFFSET 1 ROWS
FETCH NEXT 1000 ROWS ONLY
--END

--STAR
--With RowNumber we can take who/something on which place is in the ROW
SELECT TOP (1000) [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName]
      ,[Salary]
	  ,ROW_NUMBER() OVER(ORDER BY Salary DESC)
  FROM [SoftUniLec2].[dbo].[Employees]
  ORDER BY JobTitle
--END

--START
--RANK – can have gaps in its sequence and when values are the same, they get the same rank 1 2 3 3 5 6 7 There is a gap
--DENSE_RANK – returns the same rank for ties, but it doesn’t have any gaps in the sequence 1 2 3 4 5 5 6 7 No Gap
SELECT TOP (1000) [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName]
      ,[Salary]
	  ,ROW_NUMBER() OVER(ORDER BY Salary DESC)
	  ,RANK() OVER(ORDER BY Salary DESC)
	  ,DENSE_RANK() OVER(ORDER BY Salary DESC)
  FROM [SoftUniLec2].[dbo].[Employees]
  ORDER BY JobTitle
--END

--START
--NTILE – Distributes the rows in an ordered partition into a specified number of groups
SELECT * FROM
(SELECT TOP (1000) [EmployeeID]
      ,[FirstName]
      ,[LastName]
      ,[MiddleName]
      ,[Salary]
	  ,NTILE(10) OVER(ORDER BY Salary DESC) AS GroupNo
  FROM [SoftUniLec2].[dbo].[Employees]
  ORDER BY JobTitle) AS TempResults
  WHERE GroupNo = 9
--END