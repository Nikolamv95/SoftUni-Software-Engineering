CREATE PROCEDURE usp_DepositMoney(@accountId int, @moneyAmount decimal(15,4))
AS
BEGIN TRANSACTION

DECLARE @account int = (SELECT id FROM Accounts WHERE id = @accountId)

	IF(@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account id!', 16, 1)
		RETURN
	END

	IF(@moneyAmount <= 0)
	BEGIN
		ROLLBACK
		RAISERROR('Money amount should be positive number!', 16, 1)
		RETURN
	END

UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

SELECT * FROM dbo.Accounts a
EXEC usp_DepositMoney 1, 10