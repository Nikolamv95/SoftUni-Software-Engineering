--START
--This is how we concatenate strings '+'
--Variation 1
SELECT FirstName + ' ' + LastName
AS [Full Name]
FROM Employees

--Variation 2
SELECT CONCAT(FirstName, ' ', LastName)
AS [Full Name]
FROM Employee

--Variation 3
--Conact_ws is like String.Join(as a first element we put separator ' ', and after that are the values)
--If we have null value the funcion will skip it and will avoid 2 spaces
SELECT CONCAT_WS(' ', FirstName, LastName)
AS [Full Name]
FROM Employee
--END

--START
--Substring returns the length of the string which you want to work with
--SUBSTRING(String, StartIndex, Length) (SoftUni, 3, 2) -> result - 'ft'
SELECT ArticleId, Author, Content,
SUBSTRING(Content, 1, 200) + '...' AS Summary
FROM Articles
--END

--START
--This is how we replace strings
--REPLACE(String, Pattern, Replacement)
--REPLACE('SoftUni', 'Soft', 'Hard') -> result 'HardUni'
SELECT TOP(100) REPLACE([Value], 'Submittet by ', 'Lyrics by')
FROM [MusicX]
WHERE [TYPE] = 3001;

--If we want to update table we can use
--UPDATE SongMetaData SET VALUE = REPLACE([Value], 'Submittet by ', 'Lyrics by')
--WHERE [TYPE] = 3001;
--END

--START
--LTRIM - removes the whitespaces from left, RTRIM -> from right, TRIM from both sides
SELECT TRIM('        Nikola         ')
--END

--START
--LEN Ц counts the number of characters
--LEN(string)
SELECT LEN(LTRIM('         Nikola         '))
--END

--START
--DATALENGTH Ц gets the number of used bytes DATALENGTH(String)
SELECT DATALENGTH('Nikola')
--END

--START
--Always when you have char array from alphabet different than the English put N before the text to read the text
SELECT LEN(N'Ќики'), DATALENGTH(N'Ќики'), N'Ќики'
--END

--START
--LEFT & RIGHT Ц get characters from the beginning or the end of a string
--LEFT(String, Count) - give me the first left symbols
--RIGHT(String, Count) - give me the last right symbols
SELECT *,
LEFT([Name], 3) AS Shortened
FROM Games
--END

--START
--LOWER & UPPER Ц change letter casing. The same as C#
--LOWER(String)
--UPPER(String)
SELECT UPPER(N'ники')
--END

--START
--REVERSE Ц reverses order of all characters in a string REVERSE(String)
SELECT REVERSE(N'ники')
--END

--START
--REPLICATE Ц repeats a string REPLICATE(String, Count) -> count is how many times
--END

--START
--This operations change the data type same as C#
SELECT CAST(25.65 AS int);
SELECT CONVERT(int, 25.65);
--END

--START
--CHARINDEX Ц locates a specific pattern (substring) in a string - This is like Index Of in c#
--CHARINDEX(Pattern, String, [StartIndex])
--END

--START
--STUFF Ц inserts a substring at a specific position
--STUFF(String, StartIndex, Length, Substring)
--END