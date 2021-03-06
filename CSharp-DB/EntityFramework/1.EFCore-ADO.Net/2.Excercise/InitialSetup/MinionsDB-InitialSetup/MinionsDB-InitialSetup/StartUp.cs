﻿using Microsoft.Data.SqlClient;
using System;

namespace MinionsDB_InitialSetup
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SQLFacotry sqlFactory = new SQLFacotry();
            CreateDataBase(sqlFactory);
            CreateTables(sqlFactory);
            InsertInToTable(sqlFactory);
        }

        private static void InsertInToTable(SQLFacotry sqlFactory)
        {
            string insertInToCountries = "INSERT INTO Countries ([Name]) " +
                                                     "VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";

            sqlFactory.InsertIntoTable(insertInToCountries);

            string insertInToTowns = "INSERT INTO Towns ([Name], CountryCode) " +
                                     "VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1)," +
                                     "('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2)," +
                                     "('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";

            sqlFactory.InsertIntoTable(insertInToTowns);

            string insertInToMinions = "INSERT INTO Minions (Name,Age, TownId) " +
                                       "VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6)," +
                                       "('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10)," +
                                       "('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10)," +
                                       "('Zoe', 125, 5),('Json', 21, 1)";

            sqlFactory.InsertIntoTable(insertInToMinions);

            string insertInToEvilnessFactors = "INSERT INTO EvilnessFactors (Name) VALUES " +
                                               "('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";

            sqlFactory.InsertIntoTable(insertInToEvilnessFactors);

            string insertInToVillains = "INSERT INTO Villains (Name, EvilnessFactorId) " +
                                        "VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4)," +
                                        "('Rosen',5),('Dimityr',1),('Dobromir',2)";

            sqlFactory.InsertIntoTable(insertInToVillains);

            string insertInToMinionsVillains = "INSERT INTO MinionsVillains (MinionId, VillainId) " +
                                               "VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4)," +
                                               "(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";

            sqlFactory.InsertIntoTable(insertInToMinionsVillains);
        }

        private static void CreateTables(SQLFacotry sqlFactory)
        {
            string createTableCountries = "CREATE TABLE Countries " +
                                                      "(Id INT PRIMARY KEY IDENTITY, " +
                                                      "Name VARCHAR(50))";

            sqlFactory.CreateTable(createTableCountries);


            string createTableTowns = "CREATE TABLE Towns " +
                                      "(Id INT PRIMARY KEY IDENTITY," +
                                      "Name VARCHAR(50), " +
                                      "CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";

            sqlFactory.CreateTable(createTableTowns);



            string createTableMinions = "CREATE TABLE Minions " +
                                        "(Id INT PRIMARY KEY IDENTITY," +
                                        "Name VARCHAR(30), " +
                                        "Age INT, " +
                                        "TownId INT FOREIGN KEY REFERENCES Towns(Id))";

            sqlFactory.CreateTable(createTableMinions);


            string createTableEvilnessFactors = "CREATE TABLE EvilnessFactors " +
                                                "(Id INT PRIMARY KEY IDENTITY, " +
                                                "Name VARCHAR(50))";

            sqlFactory.CreateTable(createTableEvilnessFactors);

            string createTableVillains = "CREATE TABLE Villains " +
                                         "(Id INT PRIMARY KEY IDENTITY, " +
                                         "Name VARCHAR(50), " +
                                         "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";

            sqlFactory.CreateTable(createTableVillains);

            string createTableMinionsVillains = "CREATE TABLE MinionsVillains " +
                                                "(MinionId INT FOREIGN KEY REFERENCES Minions(Id)," +
                                                "VillainId INT FOREIGN KEY REFERENCES Villains(Id)," +
                                                "CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

            sqlFactory.CreateTable(createTableMinionsVillains);
        }

        private static void CreateDataBase(SQLFacotry sqlFactory)
        {
            string createDatabase = "CREATE DATABASE MinionsDB2";
            sqlFactory.CreateDataBase(createDatabase);
        }
    }
}
