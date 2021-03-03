--4. Select all users in the current game ("Bali") with their items. Display username, game name, cash and item name. 
--Sort the result by username alphabetically, then by item name alphabetically. 

SELECT u.Username, g.Name, ug.Cash, i.Name 
FROM Users AS u
JOIN UsersGames AS ug ON u.Id = ug.UserId
JOIN Games AS g ON ug.GameId = g.Id
JOIN dbo.UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.Name = 'Bali'
ORDER BY u.Username, i.Name