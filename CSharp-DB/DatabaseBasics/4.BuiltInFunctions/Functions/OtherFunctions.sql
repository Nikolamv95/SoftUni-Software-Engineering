--% -- any string, including zero-length
--_ -- any single character Manage_ only the last letter could be different
--[…] -- any character within range [A-F] like regex from A to Z any letter
--[^…] -- any character not in the range - like regex letters not in range

--START
SELECT * FROM Employees
WHERE JobTitle LIKE '%Chief%' -- before/after
--END

--START
SELECT * FROM Employees
WHERE JobTitle LIKE '%Chief' -- before
--END

--START
SELECT * FROM Employees
WHERE JobTitle LIKE 'Chief$' -- After
--END