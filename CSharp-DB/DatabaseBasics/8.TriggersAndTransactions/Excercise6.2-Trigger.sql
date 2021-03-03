--3. There are two groups of items that you must buy for the above users. The first are items with id between 251 and 299 including.
--Second group are items with id between 501 and 539 including. Take off cash from each user for the bought items.


CREATE OR ALTER PROC usp_BuyItem(@userId int, @itemId int, @gameName varchar(max))
AS
BEGIN TRANSACTION

DECLARE @gameId int = (SELECT id FROM Games WHERE [Name] = @gameName)
DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @userId)
DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)

	IF(@user IS NULL OR @item IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid user or item id!', 16, 1)
		RETURN
	END

DECLARE @userCahs decimal(15,2) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
DECLARE @itemPrice decimal(15,2) = (SELECT Price FROM Items WHERE id = @itemId)

	IF(@userCahs-@itemPrice < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient funds!', 16, 2)
		RETURN
	END

UPDATE UsersGames
SET Cash -= @itemPrice
WHERE UserId = @userId AND GameId = @gameId

INSERT INTO UserGameItems(ItemId, UserGameId) VALUES (@itemId, @gameId)
COMMIT

--Next Logic 251 - 299
DECLARE @counter int = 251;

WHILE(@counter <= 299)
BEGIN
	EXEC usp_BuyItem 22, @counter, 'Bali'
	EXEC usp_BuyItem 37, @counter, 'Bali'
	EXEC usp_BuyItem 52, @counter, 'Bali'
	EXEC usp_BuyItem 61, @counter, 'Bali'
	
	SET @counter += 1;
END

SELECT * FROM UsersGames WHERE dbo.UsersGames.UserId = 22

--Next Logic 501 - 539
DECLARE @counter2 int = 501;

WHILE(@counter <= 299)
BEGIN
	EXEC usp_BuyItem 22, @counter, 'Bali'
	EXEC usp_BuyItem 37, @counter, 'Bali'
	EXEC usp_BuyItem 52, @counter, 'Bali'
	EXEC usp_BuyItem 61, @counter, 'Bali'
	
	SET @counter += 1;
END



