--IF Statements
DECLARE @Year smallint = 1999;

SET @Year = 2021

--This is IF construction. As in C# here the result in IF is boolean type (True/False). 
--After the IF statements if the result is TRUE we can write the ACTION which we want to take, example -> SELECT GETDATE().
--IF the result is false we will go to the ELSE part and execute the code after it Example -> SELECT 'No match!'
--We can also write for multiple checks with ELSE IF
IF (@Year = DATEPART(YEAR, GETDATE()))
	SELECT GETDATE()
ELSE IF (@Year = 2029)
	SELECT 'Do Something'
ELSE
	SELECT 'No match!'

--IF we want to execute myltiple ACTION in one If, ELSE IF or ELSE CONDITION we always start With BEGIN and then END
--BEGIN and END are like { } open/close brackets
IF (@Year = DATEPART(YEAR, GETDATE()))
BEGIN
	SELECT GETDATE()
	SELECT 'Do action'
END
ELSE IF (@Year = 2029)
BEGIN
	SELECT 'Do Something'
	SELECT 'Do Something'
	SELECT 'Do Something'
END
ELSE
	SELECT 'No match!'