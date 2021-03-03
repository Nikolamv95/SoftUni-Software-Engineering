-START
--This is how we create Foreign Key with code One-To-Many
 
--We created table Mountains
CREATE TABLE Mountains(
MountainID INT PRIMARY KEY,
MountainName VARCHAR(50)
)
 
--This is table Peaks and every Peak will have a column  MountainID which will be a reference to the
--table Mountains column MountainID
CREATE TABLE Peaks(
PeakId INT PRIMARY KEY,
MountainID INT,
CONSTRAINT FK_Peaks_Mountains
FOREIGN KEY (MountainID)
REFERENCES Mountains(MountainID)
)
-END
 
--START
--If we want to use a Many-to-many relationship we have to create an intermediate table that will keep the foreign keys
--of the tables which we want to connect. Example Student table to be connected with Courses table.
 
CREATE TABLE StudentCourses(
StudentID INT,
CourseID INT,
 
CONSTRAINT PK_StudentCourses
PRIMARY KEY(StudentID, CourseID),
 
CONSTRAINT FK_StudentCourses_Students
FOREIGN KEY(StudentID)
REFERENCES Students(StudentID),
 
CONSTRAINT FK_StudentCourses_Courses
FOREIGN KEY(CourseID)
REFERENCES Projects(CourseID)
)
--END
 
--START
--This is how we Join (concate) two tables
SELECT * 
FROM Courses AS c
JOIN Town AS t ON Countries.Id = Towns.CountryId
 
--Also we can access only the columns which are needed
--Keep remember that when we join FROM (TABLE) is always the biggest abstraction
--example Towns are in Countries so Countries is the biggest abstraction.
--Also, in SELECT with c. and t. we can select every column which we want in random order
SELECT c.CourseName, t.Name, t.Population
FROM Courses AS c
JOIN Town AS t ON Countries.Id = Towns.CountryId
Where t.Population >= 300000 -- if we want we can filter the table also
 
--This is example (again Peaks are in Mountain, so Mountain are the biggest abstraction)
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks As p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
 
--We can take multiple JOINS one after another 3:51 from the Lecture Niki Kostov
--END
 