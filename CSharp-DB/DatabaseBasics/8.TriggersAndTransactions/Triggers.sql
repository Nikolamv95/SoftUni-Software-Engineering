--A trigger is a special type of stored procedure that automatically runs when an event occurs in the database server.

--IMPORTANT!!!!!!!!!!!!!!!!!!!!!!!
--In the triggers we have 2 virtual tables Inserted (when we want to insert something somewhere) and deleted (when we want to delete something)
--They are something like variable table with values which we will take and place in our code which wll be executed in the trigger
--WHEN WE USE (FOR, INSTED OF) UPDATE the old values are keeping in virtual dable deleted and the new values are in inserted check example 3 down


--EXAMPLE FOR

--FOR Update,Delete,Insert means that before the operation we have to execute some code, and after that we will make the changes
--Inserted is vurtual table which contains all values WHERE TownId=1
--CREATING THE TRIGGER
CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE
AS
	IF (EXISTS(
		SELECT * FROM inserted
		WHERE Name IS NULL OR LEN(Name) = 0))
	BEGIN
		RAISERROR('Town name cannot be empty.', 16, 1)
		ROLLBACK
		RETURN
	END
GO

--TRY TO UPDATE the name
UPDATE Towns SET Name='' WHERE TownId=1
--It will return 'Town name cannot be empty.', 16, 1. because the name is blank space

--EXAMPLE INSTEAD OF
--Instead of something means that instead of the real DELETE,INSERT,UPDATE something we will change this behavior
--with operation which we want for the table which we created the trigger
--Deleted is virtual table which contains the valuse WHERE [FirstName] LIKE 'M%'
CREATE OR ALTER TRIGGER tr_SetIsDeletedOnDelete ON AccountHolders
INSTEAD OF DELETE
AS
	UPDATE AccountHolders SET IsDeleted = 1
	WHERE id IN (SELECT id FROM deleted)
GO

DELETE FROM AccountHolders WHERE [FirstName] LIKE 'M%'

SELECT * FROM AccountHolders



--EXAMPLE 3
--We will record all the changes in another table before the changes are done (FOR UPDATE)
CREATE TABLE Logs
(
	Id int IDENTITY PRIMARY	 KEY,
	AccountId int REFERENCES Accounts(Id),
	OldAmmount money NOT NULL,
	NewAmmount money NOT NULL,
	UpdatedOn datetime,
	UpdatedBy nvarchar(max), 
)

--We take the old values from virtual table deleted, and the new values from virtual table inserted
CREATE TRIGGER tr_AddToLogsOnAccountUpdate 
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountId, OldAmmount, NewAmmount, UpdatedOn, UpdatedBy)
	SELECT i.id,d.Balance,i.Balance,GETDATE(),CURRENT_USER
	FROM inserted AS i
	JOIN deleted AS d ON i.id = d.id
	WHERE i.Balance != d.Balance
GO

UPDATE Accounts SET Balance = 0 WHERE Accounts.Id = 1
SELECT * FROM dbo.Accounts a WHERE a.Id = 1

SELECT * FROM dbo.Logs l
