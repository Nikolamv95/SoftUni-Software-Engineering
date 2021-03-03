using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;

namespace IncreaseAgeStoredProcedure
{
    class StartUp
    {
        private const string ConnectionMinionsDB2 =
                            @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();

            int minionId = int.Parse(Console.ReadLine());

            string result = IncreaseMinionAgeById(sqlConnection, minionId);

            Console.WriteLine(result);
        }

        private static string IncreaseMinionAgeById(SqlConnection sqlConnection, int minionId)
        {
            StringBuilder sb = new StringBuilder();

            //Increase ages
            string procName = "usp_GetOlder";
            using SqlCommand increaseAgeCmd = new SqlCommand(procName, sqlConnection);
            increaseAgeCmd.CommandType = CommandType.StoredProcedure;
            increaseAgeCmd.Parameters.AddWithValue("@minionId", minionId);
            increaseAgeCmd.ExecuteNonQuery();

            //Get minions data
            string getMinionsQueryText = "SELECT [Name], Age " +
                                         "FROM Minions " +
                                         "WHERE id = @minionId";

            using SqlCommand getMinionsCmd = new SqlCommand(getMinionsQueryText, sqlConnection);
            getMinionsCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader reader = getMinionsCmd.ExecuteReader();
            reader.Read();

            string minionName = reader["Name"]?.ToString().Trim();
            string minionAge = reader["Age"]?.ToString().Trim();

            sb.AppendLine($"{minionName} – {minionAge} years old");

            return sb.ToString().Trim();
        }
    }
}
