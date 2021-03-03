--START
--Variation 1 with Alter Table  - Excercise 1
CREATE TABLE Persons(
PersonID INT NOT NULL,
FirstName NVARCHAR(25),
Salary DECIMAL(8,2),
PassportID INT UNIQUE
)

CREATE TABLE Passports
(
PassportID INT NOT NULL UNIQUE,
PassportNumber NVARCHAR(25)
)

INSERT INTO Persons(PersonID,FirstName,Salary,PasportID)
VALUES
(1,'Roberto',43300.00, 102),
(2,'Tom',56100.00, 103),
(3,'Yana',60200.00, 101)

INSERT INTO Passports(PasportID, PassportNumber)
VALUES 
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

ALTER TABLE Persons
ADD CONSTRAINT pk_PersonID PRIMARY KEY (PersonalID)
ALTER TABLE Passports
ADD CONSTRAINT pk_PassportsID PRIMARY KEY ([PassportID])

ALTER TABLE Persons
ADD CONSTRAINT fk_Pesrons_Passports FOREIGN KEY([PassportID])
REFERENCES Passports([PassportID])


--Variation 2 - Excercise 1

CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber CHAR(8) NOT NULL
);

--IN ONE-TO-ONE relationship we use the word UNIQE
CREATE TABLE Persons(
	PersonID INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL (7,2) NOT NULL,
	PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
);

INSERT INTO Passports (PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons (PersonID, [FirstName], Salary, PassportID)
VALUES
(1, 'Roberto', 43300, 102),
(2, 'Tom', 56100, 103),
(3, 'Yana', 60200, 101)
--Excercise 1 START

--Excercise 2 START
CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY,
[Name] VARCHAR(20) NOT NULL,
EstablishedOn DATE NOT NULL
);

INSERT INTO Manufacturers (ManufacturerID, [Name], EstablishedOn)
VALUES
(1, 'BMW', '1916/03/07'),
(2, 'Tesla', '2003/01/01'),
(3, 'Lada', '1966/05/01')

CREATE TABLE Models(
ModelID INT  NOT NULL PRIMARY KEY,
[Name] VARCHAR(20) NOT NULL,
ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Models (ModelID, [Name], ManufacturerID)
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

SELECT * FROM Models
SELECT * FROM Manufacturers
--Excercise 2 END

--Excercise 3 START
CREATE TABLE Students(
StudentID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(20) NOT NULL
);

CREATE TABLE Exams(
ExamID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(20) NOT NULL
);

INSERT INTO Students (StudentID, [Name])
VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams (ExamID, [Name])
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

CREATE TABLE StudentsExams(
StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
CONSTRAINT PK_Student_Exams PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)
--Excercise 3 END

--Excercise 4 START
CREATE TABLE Teachers(
TeacherID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(20) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers (TeacherID, [Name], ManagerID)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

SELECT * FROM Teachers
--Excercise 4 END

--Excercise 5 - START
CREATE TABLE Cities(
CityID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE ItemTypes(
ItemTypeID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Customers(
CustomerID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
Birthday DATE NOT NULL,
CityID INT NOT NULL FOREIGN KEY REFERENCES Cities(CityID)
);

CREATE TABLE Items(
ItemID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
ItemTypeID INT NOT NULL FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
);

CREATE TABLE Orders(
OrderID INT NOT NULL PRIMARY KEY,
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems(
OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT NOT NULL FOREIGN KEY REFERENCES Items(ItemID),
CONSTRAINT PK_Orders_Items PRIMARY KEY(OrderID,ItemID)
);
--Excercise 5 - END

--Excercise 6 - START
CREATE TABLE Subjects(
SubjectID INT NOT NULL PRIMARY KEY,
SubjectName VARCHAR(50) NOT NULL,
);

CREATE TABLE Majors(
MajorID INT NOT NULL PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Students(
StudentID INT NOT NULL PRIMARY KEY,
StudentNumber VARCHAR(50) NOT NULL,
StudentName VARCHAR(50) NOT NULL,
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
);

CREATE TABLE Agenda(
StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT PK_Students_Subjects PRIMARY KEY(StudentID,SubjectID)
);

CREATE TABLE Payments(
PaymentID INT NOT NULL PRIMARY KEY,
PaymentDate DATETIME2 NOT NULL,
PaymentAmount DECIMAL (7,4) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
);
--Excercise 6 - END

--Excercise 9 - START
USE [Geography]
SELECT * FROM Peaks
SELECT * FROM Mountains 

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
--Excercise 9 - END