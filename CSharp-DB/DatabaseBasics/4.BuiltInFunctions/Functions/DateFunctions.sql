--START
--Always save the dateTime in UTC - GMT
--END

--START
--DATEPART – extract a segment from a date as an integer
SELECT *, DATEPART(YEAR, HireDate) AS NewHireDate
	FROM Employees

SELECT *, DATEPART(MONTH, HireDate) AS NewHireDate
	FROM Employees

SELECT *, DATEPART(DAY, HireDate) AS NewHireDate
	FROM Employees


SELECT 
	[Name], 
	[Description],
	DATEPART(QUARTER, StartDate) AS [Quarter],
	DATEPART(MONTH, StartDate) AS [Month],
	DATEPART(YEAR, StartDate) AS [Year],
	DATEPART(DAY, StartDate) AS [Day]
	FROM Projects
--END

--START
--DATEDIFF – finds the difference between two dates DATEDIFF(Part, FirstDate, SecondDate)
SELECT 
	[Name], 
	[Description],
	DATEDIFF(MONTH, StartDate, EndDate) AS Difference
	FROM Projects
--END

--START
--DATENAME – gets a string representation of a date's part DATENAME(Part, Date)
SELECT DATENAME(weekday, '2017/01/27')
--END

--START
--DATEADD – performs date arithmetic
SELECT DATEADD(MINUTE, 5, '2017/01/27')
--END

--START
--GETDATE – obtains the current date and time
SELECT GETDATE()
--END