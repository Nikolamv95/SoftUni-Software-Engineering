--4. Withdraw Money
CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION

DECLARE @account int = (SELECT id FROM Accounts WHERE id = @accountId)

	IF(@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account id!', 16, 1)
		RETURN
	END

	IF (@moneyAmount < 0 OR @moneyAmount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 1)
		RETURN
	END

	DECLARE @currAmount money = (SELECT Balance FROM Accounts WHERE Id = @accountId)

	IF(@moneyAmount > @currAmount)
	BEGIN
		ROLLBACK
		RAISERROR('Not sufficient amount', 16, 2)
		RETURN
	END


UPDATE Accounts
	   SET Balance -= @moneyAmount
	   WHERE Id = @accountId
COMMIT

SELECT * FROM dbo.Accounts a
EXEC usp_WithdrawMoney 5, 25

