--2. Add bonus cash of 50000 to users: baleremuda, loosenoise, inguinalself, buildingdeltoid, monoxidecos in the game "Bali".

DECLARE @baleremudaID int = (SELECT id FROM Users WHERE Username = 'baleremuda');
DECLARE @loosenoiseID int = (SELECT id FROM Users WHERE Username = 'loosenoise');
DECLARE @inguinalselfID int = (SELECT id FROM Users WHERE Username = 'inguinalself');
DECLARE @buildingdeltoidID int = (SELECT id FROM Users WHERE Username = 'buildingdeltoid');
DECLARE @monoxidecosID int = (SELECT id FROM Users WHERE Username = 'monoxidecos');

DECLARE @gameId int = (SELECT id FROM Games WHERE [Name] = 'Bali')

UPDATE UsersGames SET Cash -= 50000 
WHERE UserId IN (@baleremudaID, @loosenoiseID, @inguinalselfID, @buildingdeltoidID, @monoxidecosID)