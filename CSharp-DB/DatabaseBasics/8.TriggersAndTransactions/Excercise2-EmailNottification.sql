--2. Create Table Emails
CREATE TABLE NotificationEmails(
	LogId int IDENTITY PRIMARY KEY ,
	Recipient int FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] varchar(max),
	Body varchar(max)
)

CREATE OR ALTER TRIGGER	tr_CreateEmailNottification
ON Logs FOR INSERT
AS
BEGIN

DECLARE @Recipient int;
DECLARE @Subject varchar(max);
DECLARE @Body varchar(max);

SET @Recipient = (SELECT i.AccountId FROM INSERTED AS i);
SET @Subject = 'Balance change for account: ' + CAST(@Recipient AS varchar(max));
SET @Body = 'On ' 
			+ CAST(GETDATE() AS varchar(max))
			+ ' your balance was changed from ' 
			+ CAST((SELECT d.OldSum FROM INSERTED AS d) AS varchar(max)) 
			+ ' to '
			+ CAST((SELECT i.NewSum FROM INSERTED AS i) AS varchar(max));

INSERT INTO NotificationEmails(Recipient, [Subject], Body)
VALUES(@Recipient, @Subject, @Body)
END

UPDATE Accounts SET Balance = 120000 WHERE Accounts.Id = 1
SELECT * FROM dbo.Accounts a WHERE a.Id = 1
SELECT * FROM dbo.NotificationEmails ne