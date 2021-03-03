--1. Users should not be allowed to buy items with higher level than their level. Create a trigger that restricts that. 
--The trigger should prevent inserting items that are above specified level while allowing all others to be inserted.

SELECT * FROM USERS AS u
JOIN UsersGames AS ug ON u.Id = ug.Id
JOIN Items AS i ON ug.Id = i.Id

SELECT ug.* FROM dbo.UsersGames ug

CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId int = (SELECT i.itemId FROM INSERTED AS i)
DECLARE @userGameId int = (SELECT i.UserGameId FROM INSERTED AS i)

DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
DECLARE @userGameLevel Int = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

IF(@itemLevel <= @userGameLevel)
BEGIN
	INSERT INTO UserGameItems(ItemId, UserGameId) 
		VALUES (@itemId, @userGameId)
END

--UserGameId -38 is a player with leve 20
--ItemId -2 is an item with level 34
--The result should not add the item into the mapping table UserGameItems

SELECT * FROM UserGameItems 
WHERE UserGameId = 38 AND ItemId = 2

INSERT INTO UserGameItems(ItemId, UserGameId) 
VALUES(2,38)

--UserGameId -38 is a player with leve 20
--ItemId -14 is an item with level 17
--The result should not add the item into the mapping table UserGameItems

SELECT * FROM UserGameItems 
WHERE UserGameId = 38 AND ItemId = 14

INSERT INTO UserGameItems(ItemId, UserGameId) 
VALUES(14,38)