--Loop Statement
DECLARE @Year smallint = 1999;

--The logic is simillar to C#, the difference here is BEGIN/END -> like { } 
WHILE @Year <= 2005
BEGIN
	SELECT @Year, COUNT(*) FROM [Employees] WHERE DATEPART(YEAR, [HireDate]) = @Year;
	SET @Year += 1
END

--CONTINUE and BREAK same as C#
WHILE @Year <= 2005
BEGIN
	SELECT @Year, COUNT(*) FROM [Employees] WHERE DATEPART(YEAR, [HireDate]) = @Year;
	SET @Year += 1
		IF(@Year = 2005)
			BREAK -- Will break the loop
END

WHILE @Year <= 2005
BEGIN
	IF(@Year = 2005)
			CONTINUE -- Will skip the rest rows and continue again with the while statement
	SELECT @Year, COUNT(*) FROM [Employees] WHERE DATEPART(YEAR, [HireDate]) = @Year;
	SET @Year += 1		
END

