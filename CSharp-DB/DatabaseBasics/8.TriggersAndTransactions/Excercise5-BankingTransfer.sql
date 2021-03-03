CREATE PROC usp_TransferMoney(@senderId int, @receiverId int, @amount decimal (15,4))
AS
BEGIN TRANSACTION

	IF (@amount < 0 OR @amount IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money', 16, 1)
			RETURN
		END

DECLARE @currAmount money = (SELECT Balance FROM Accounts WHERE Id = @senderId)

	IF(@amount > @currAmount)
		BEGIN
			ROLLBACK
			RAISERROR('Not sufficient amount', 16, 2)
			RETURN
		END


DECLARE @sender int = (SELECT id FROM Accounts WHERE id = @senderId)

	IF(@sender IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid sender id!', 16, 1)
			RETURN
		END

DECLARE @receiver int = (SELECT id FROM Accounts WHERE id = @receiverId)

	IF(@receiver IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid receiver id!', 16, 1)
			RETURN
		END

UPDATE Accounts SET Balance -= @amount WHERE Id = @senderId
UPDATE Accounts SET Balance += @amount WHERE Id = @receiverId
COMMIT

EXEC usp_TransferMoney 5, 1, 5000
SELECT * FROM Accounts