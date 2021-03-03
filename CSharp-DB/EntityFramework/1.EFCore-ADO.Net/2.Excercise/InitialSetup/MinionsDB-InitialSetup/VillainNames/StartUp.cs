using Microsoft.Data.SqlClient;
using System;

namespace VillainNames
{
    class StartUp
    {

        private const string ConnectionMinionsDB2 = 
                             @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        static void Main(string[] args)
        {
            string checkVillainsNumMinions = "SELECT v.Name, COUNT(MinionId) AS NumMinions " +
                                             "FROM Villains AS v LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                                             "GROUP BY v.Id, v.Name " +
                                             "HAVING COUNT(MinionId) > 2 ORDER BY v.Name;";

            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();

            SqlCommand myCommand = new SqlCommand(checkVillainsNumMinions, sqlConnection);
            ReadDataFromTheTable(myCommand);

        }

        public static void ReadDataFromTheTable(SqlCommand myCommand)
        {
            using (SqlDataReader reader2 = myCommand.ExecuteReader())
            {
                while (reader2.Read() == true)
                {
                    string villainName = (string)reader2["Name"];//check
                    int numOfMinions = (int)reader2["NumMinions"];
                    Console.WriteLine($"{villainName} {numOfMinions}");
                }
            }
        }
    }
}
