CREATE DATABASE People

GO

USE People

--Create table People
CREATE TABLE People
(Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX)
CHECK(DATALENGTH(Picture) <= 2000000),
Height DECIMAL(38,2),
[Weight] DECIMAL(38,2),
Gender CHAR(1)  NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(max))

--Insert data in to table People
INSERT INTO People([Name], Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Pesho0', '123', '123123', 0, '01.29.2021', 'dddddddddd'),
('Pesho1', '123', '123123', 0, '01.29.2021', 'dddddddddd'),
('Pesho2', '123', '123123', 1, '01.29.2021', 'dddddddddd'),
('Pesho3', '123', '123123', 0, '01.29.2021', 'dddddddddd'),
('Pesho4', '123', '123123', 1, '01.29.2021', 'dddddddddd')

--Create table Users
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX)
CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime DATETIME2 NOT NULL,
IsDeleted BIT NOT NULL)

--Insert data in to table Users
INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Pesho0', '123456', '01.29.2021', 0),
('Pesho1', '123456', '01.29.2021', 1),
('Pesho2', '123456', '01.29.2021', 0),
('Pesho3', '123456', '01.29.2021', 0),
('Pesho4', '123456', '01.29.2021', 1)

--Delete primary key from table Users
ALTER TABLE Users
DROP CONSTRAINT	[PK__Users__3214EC071896DCE8]

--Add PKey as a combination of ID and Username
ALTER TABLE Users
 ADD CONSTRAINT PK_Users_CompsoiteIdUsername 
 PRIMARY KEY (Id, Username)

 --Check Constraint condition which the input has to cover
 ALTER TABLE Users
  ADD CONSTRAINT CK_Users_PasswordLength
  CHECK(LEN([Password])>= 5)

--MAKE the current time LastLoginTime
ALTER TABLE Users
 ADD CONSTRAINT DF_Users_LastLoginTime
 DEFAULT GETDATE() FOR LastLoginTime

--Delete primary key from table Users
ALTER TABLE	Users
DROP CONSTRAINT PK_Users_CompsoiteIdUsername 

--Add PKey to be ID
ALTER TABLE Users
 ADD CONSTRAINT PK_Users_Id
 PRIMARY KEY (Id)

--Check Constraint condition which the input has to cover
 ALTER TABLE Users
 ADD CONSTRAINT CK_Users_UsernameLength
 CHECK(LEN(Username)>= 3)


CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
 Id INT PRIMARY KEY IDENTITY NOT NULL,
 DirectorName NVARCHAR(30) NOT NULL,
 Notes NVARCHAR(max))

INSERT INTO Directors(DirectorName, Notes)
VALUES
('Pesho0', 'koletokoleto'),
('Pesho1', 'koletokoleto'),
('Pesho2', 'koletokoleto'),
('Pesho3', NULL),
('Pesho4', NULL)


CREATE TABLE Genres(
 Id INT PRIMARY KEY IDENTITY NOT NULL,
 GenreName NVARCHAR(30) NOT NULL,
 Notes NVARCHAR(max))

INSERT INTO Genres(GenreName, Notes)
VALUES
('Vanko', 'koletokoleto'),
('Vanko1', 'koletokoleto'),
('Vanko2', 'koletokoleto'),
('Vanko3', NULL),
('Vanko4', NULL)

CREATE TABLE Categories (
 Id INT PRIMARY KEY IDENTITY NOT NULL,
 CategoryName NVARCHAR(30) NOT NULL,
 Notes NVARCHAR(max))

INSERT INTO Categories(CategoryName, Notes)
VALUES
('Asterix', 'koletokoleto'),
('Asterix1', 'koletokoleto'),
('Asterix2', 'koletokoleto'),
('Asterix3', NULL),
('Asterix4', NULL)

CREATE TABLE Movies (
      Id INT PRIMARY KEY IDENTITY NOT NULL,
      Title NVARCHAR(30) NOT NULL,
      DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	  CopyrightYear DATE NOT NULL,
      [Length] INT NOT NULL,
      GenreId INT FOREIGN KEY REFERENCES Genres(Id),
      CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
      Rating DECIMAL(32,8) NOT NULL,
      Notes NVARCHAR(max))

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
('Moive', 1, '02.10.2020', 120, 1, 1, 5, 'TOP'),
('Moive1', 2, '02.10.2020', 120, 2, 2, 5, 'TOP'),
('Moive2', 3, '02.10.2020', 120, 3, 3, 5, 'TOP'),
('Moive3', 4, '02.10.2020', 120, 4, 4, 5, 'TOP'),
('Moive4', 5, '02.10.2020', 120, 5, 5, 5, 'TOP')

SELECT * FROM Directors 
SELECT * FROM Genres 
SELECT * FROM Categories 
SELECT * FROM Movies 
 