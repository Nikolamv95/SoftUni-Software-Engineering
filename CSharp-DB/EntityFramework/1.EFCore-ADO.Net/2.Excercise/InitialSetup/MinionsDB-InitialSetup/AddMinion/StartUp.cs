using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace AddMinion
{
    public class StartUp
    {
        private const string ConnectionMinionsDB2 =
                            @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();

            string[] minionData = TakeMinionData();
            string[] villainData = TakeVillainData();

            bool isTownNotExist = IsTownExist(minionData, sqlConnection);

            if (isTownNotExist)
            {
                AddTownToTableTowns(sqlConnection, minionData[2]);
                Console.WriteLine($"Town {minionData[2]} was added to the database.");
            }

            bool isVillainNotExist = IsVillainExist(villainData[0], sqlConnection);

            if (isVillainNotExist)
            {
                AddVillainToTable(sqlConnection, villainData[0]);
                Console.WriteLine($"Villain {villainData[0]} was added to the database.");
            }

            int townId = GetTownId(sqlConnection, minionData[2]);

            AddMinionToTable(sqlConnection, townId, minionData);

            int minionId = GetMinionId(sqlConnection, minionData);
            int villainId = GetVillainId(sqlConnection, villainData[0]);

            AddMinnionToVillian(minionId, villainId, sqlConnection);
            Console.WriteLine($"Successfully added {minionData[0]} to be minion of {villainData[0]}.");
        }

        private static int GetTownId(SqlConnection sqlConnection, string townName)
        {
            string checkTown = "SELECT Id FROM Towns WHERE Name = @TownName";
            SqlCommand myCommand = new SqlCommand(checkTown, sqlConnection);
            myCommand.Parameters.AddWithValue("@TownName", townName);
            int result = (int)myCommand.ExecuteScalar();
            return result;
        }

        private static int GetVillainId(SqlConnection sqlConnection, string villainName)
        {
            string checkVillain = "SELECT Id FROM Villains WHERE Name = @VillainName";
            SqlCommand myCommand = new SqlCommand(checkVillain, sqlConnection);
            myCommand.Parameters.AddWithValue("@VillainName", villainName);
            int result = (int)myCommand.ExecuteScalar();
            return result;
        }

        private static int GetMinionId(SqlConnection sqlConnection, string[] minionData)
        {
            string checkMinion = "SELECT Id FROM Minions WHERE Name = @MinnionName";
            SqlCommand myCommand = new SqlCommand(checkMinion, sqlConnection);
            myCommand.Parameters.AddWithValue("@MinnionName", minionData[0]);
            int result = (int)myCommand.ExecuteScalar();
            return result;
        }

        private static void AddMinnionToVillian(int minionId, int villainId, SqlConnection sqlConnection)
        {
            string addMinnionToVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) " +
                                         "VALUES (@MinionId, @VillainId)";

            SqlCommand myCommand = new SqlCommand(addMinnionToVillain, sqlConnection);
            myCommand.Parameters.AddWithValue("@MinionId", minionId);
            myCommand.Parameters.AddWithValue("@VillainId", villainId);
            myCommand.ExecuteNonQuery();
        }

        private static void AddMinionToTable(SqlConnection sqlConnection, int townId, string[] minionData)
        {
            string addVillainToTable = "INSERT INTO Minions([Name], Age, TownId) VALUES (@MinionName, @MinionAge, @TownId)";
            SqlCommand myCommand = new SqlCommand(addVillainToTable, sqlConnection);
            myCommand.Parameters.AddWithValue("@MinionName", minionData[0]);
            myCommand.Parameters.AddWithValue("@MinionAge", int.Parse(minionData[1]));
            myCommand.Parameters.AddWithValue("@TownId", townId);
            myCommand.ExecuteNonQuery();
        }       

        private static void AddVillainToTable(SqlConnection sqlConnection, string villainName)
        {
            string addVillainToTable = "INSERT INTO Villains([Name], [EvilnessFactorId]) VALUES (@VillainName, 4)";
            SqlCommand myCommand = new SqlCommand(addVillainToTable, sqlConnection);
            myCommand.Parameters.AddWithValue("@VillainName", villainName);
            myCommand.ExecuteNonQuery();
        }

        private static bool IsVillainExist(string villainName, SqlConnection sqlConnection)
        {
            bool isNotExist = true;

            string checkVillain = "SELECT [Name] FROM Villains WHERE Name = @VillainName";
            SqlCommand myCommand = new SqlCommand(checkVillain, sqlConnection);
            myCommand.Parameters.AddWithValue("@VillainName", villainName);
            string name = (string)myCommand.ExecuteScalar();

            if ((name != "") && (name != null))
            {
                isNotExist = false;
            }

            return isNotExist;
        }

        private static void AddTownToTableTowns(SqlConnection sqlConnection, string townToAdd)
        {
            string addTownToTable = "INSERT INTO Towns([Name]) VALUES (@TownName)";
            SqlCommand myCommand = new SqlCommand(addTownToTable, sqlConnection);
            myCommand.Parameters.AddWithValue("@TownName", townToAdd);
            myCommand.ExecuteNonQuery();
        }

        private static bool IsTownExist(string[] minionData, SqlConnection sqlConnection)
        {
            bool isNotExist = true;

            string checkTown = "SELECT [Name] FROM Towns WHERE Name = @TownName";
            SqlCommand myCommand = new SqlCommand(checkTown, sqlConnection);
            myCommand.Parameters.AddWithValue("@TownName", minionData[2]);
            string name = (string)myCommand.ExecuteScalar();

            if ((name != "") && (name != null))
            {
                isNotExist = false;
            }

            return isNotExist;
        }

        private static string[] TakeVillainData()
        {
            string[] villainData = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            villainData = villainData.Skip(1).ToArray();
            return villainData;
        }

        private static string[] TakeMinionData()
        {
            string[] minionData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            minionData = minionData.Skip(1).ToArray();
            return minionData;
        }
    }
}
