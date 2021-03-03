using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace AddMinionV2
{
    class StartUp
    {
        private const string ConnectionMinionsDB2 =
                            @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();

            string[] minionData = TakeMinionData();
            string[] villainData = TakeVillainData();

            string result = AddMinionToDatabase(sqlConnection, minionData, villainData);
            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionData, string[] villainData)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minionData[0];
            string minionAge = minionData[1];
            string minionTown = minionData[2];

            string villainName = villainData[0];

            string townId = EnsureTownExists(sqlConnection, minionTown, output);
            string villainId = EnsureVillainExists(sqlConnection, villainName, output);

            string addMinionToDB = "INSERT INTO Minions([Name], Age, TownId) " +
                                       "VALUES (@MinionName, @MinionAge, @TownId)";

            using SqlCommand insertMinionCmd = new SqlCommand(addMinionToDB, sqlConnection);

            insertMinionCmd.Parameters.AddWithValue("@MinionName", minionName);
            insertMinionCmd.Parameters.AddWithValue("@MinionAge", minionAge);
            insertMinionCmd.Parameters.AddWithValue("@TownId", townId);

            insertMinionCmd.ExecuteNonQuery();

            string minionID = GetMinionId(sqlConnection, minionName);

            AddMinnionToVillian(minionID, villainId, sqlConnection, output, minionName, villainName);

            return output.ToString();
        }


        private static void AddMinnionToVillian(string minionId, string villainId, SqlConnection sqlConnection, StringBuilder output, string minionName, string villainName)
        {
            string addMinnionToVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) " +
                                         "VALUES (@MinionId, @VillainId)";

            using SqlCommand myCommand = new SqlCommand(addMinnionToVillain, sqlConnection);
            myCommand.Parameters.AddWithValue("@MinionId", minionId);
            myCommand.Parameters.AddWithValue("@VillainId", villainId);
            myCommand.ExecuteNonQuery();

            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static string GetMinionId(SqlConnection sqlConnection, string minionName)
        {
            string checkMinion = "SELECT Id FROM Minions WHERE Name = @MinnionName";

            using SqlCommand getMinionId = new SqlCommand(checkMinion, sqlConnection);
            getMinionId.Parameters.AddWithValue("@MinnionName", minionName);
            string minionId = getMinionId.ExecuteScalar().ToString();

            return minionId;
        }

        //Checks if given villain exists in the database. If it does not exitsm then insert it and return VillainId.
        private static string EnsureVillainExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string checkVillain = "SELECT Id FROM Villains " +
                                  "WHERE Name = @VillainName";

            using SqlCommand getVillainId = new SqlCommand(checkVillain, sqlConnection);
            getVillainId.Parameters.AddWithValue("@VillainName", villainName);
            string villainId = getVillainId.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string addVillainToTable = "INSERT INTO Villains([Name], [EvilnessFactorId]) " +
                                           "VALUES (@VillainName, 4)";

                using SqlCommand addVillainToDB = new SqlCommand(addVillainToTable, sqlConnection);
                addVillainToDB.Parameters.AddWithValue("@VillainName", villainName);
                addVillainToDB.ExecuteNonQuery();

                villainId = getVillainId.ExecuteScalar().ToString();

                output.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        //Checks if given town exists in the database. If it does not exitsm then insert it and return TownId.
        private static string EnsureTownExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string checkTown = "SELECT Id FROM Towns " +
                               "WHERE Name = @TownName";

            using SqlCommand getTwonIdCmd = new SqlCommand(checkTown, sqlConnection);
            getTwonIdCmd.Parameters.AddWithValue("@TownName", minionTown);
            string townId = getTwonIdCmd.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string addTownToTable = "INSERT INTO Towns([Name], CountryCode) " +
                                        "VALUES (@TownName, 1)";

                using SqlCommand insertTownCmd = new SqlCommand(addTownToTable, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@TownName", minionTown);
                insertTownCmd.ExecuteNonQuery();

                townId = getTwonIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId;
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
