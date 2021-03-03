CREATE PROCEDURE usp_TransferFunds(@fromAccountId int, @toAccountId int, @amount money)
AS
BEGIN TRANSACTION -- REQUIRED
	
	IF(@amount <= 0)
		BEGIN
			ROLLBACK; -- REQUIRED
			THROW 50001, 'Amount can not be negative number', 1; -- REQUIRED
		END

	IF((SELECT COUNT(*) FROM Accounts WHERE Id = @fromAccountId) != 1)
		BEGIN
			ROLLBACK;
			THROW 50002, 'Invalid @fromAccountId.', 1;
		END

	IF((SELECT COUNT(*) FROM Accounts WHERE Id = @toAccountId) != 1)
		BEGIN			THROW 50003, 'Invalid @toAccountId.', 1;
		END

	IF((SELECT Balance FROM Accounts WHERE Id = @toAccountId) > @amount)

			ROLLBACK;
		BEGIN
			ROLLBACK;
			THROW 50004, 'Insufficient funds in @fromAccountId.', 1;
		END

	UPDATE Accounts SET Balance = Balance - @amount WHERE Id = @fromAccountId;
	UPDATE Accounts SET Balance = Balance + @amount WHERE Id = @toAccountId;
COMMIT -- REQUIRED
GO