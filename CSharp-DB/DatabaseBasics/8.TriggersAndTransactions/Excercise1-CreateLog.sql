--1. Create Table Logs
CREATE TABLE Logs(
	LogId int IDENTITY PRIMARY KEY ,
	AccountId int REFERENCES Accounts(Id),
	OldSum money NOT NULL,
	NewSum money NOT NULL
)

CREATE TRIGGER	tr_AddToLogsOnAccountUpdate 
ON Accounts FOR UPDATE
AS
BEGIN
INSERT INTO Logs(AccountId, OldSum, NewSum)
SELECT i.Id,d.Balance,i.Balance FROM INSERTED AS i
JOIN DELETED AS d ON i.Id = d.Id
END

UPDATE Accounts SET Balance = 0 WHERE Accounts.Id = 1
SELECT * FROM dbo.Accounts a WHERE a.Id = 1
SELECT * FROM dbo.Logs l