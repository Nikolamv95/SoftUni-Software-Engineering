using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace MinionNames
{
    class StartUp
    {
        private const string ConnectionMinionsDB2 =
                            @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();

            int villainId = int.Parse(Console.ReadLine());

            string villainname = GetVillainName(sqlConnection, villainId);

            if (villainname != null)
            {
                Console.WriteLine($"Villain: {villainname}");

                string result = ReadDataFromTheTable(sqlConnection, villainId);
                Console.WriteLine(result);
            }
        }

        private static string GetVillainName(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string checkVillainName = "SELECT Name FROM Villains " +
                                      "WHERE id = @VillainId";

            SqlCommand myCommand = new SqlCommand(checkVillainName, sqlConnection);

            myCommand.Parameters.AddWithValue("@VillainId", villainId);

            string villainname = myCommand.ExecuteScalar()?.ToString();


            if (villainname == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }

            return villainname;
        }

        private static string ReadDataFromTheTable(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string takeVillainMinions = "SELECT m.Name, m.Age FROM Villains AS v " +
                                        "LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                                        "LEFT JOIN Minions AS m ON mv.MinionId = m.Id " +
                                        "WHERE v.Id = @VillainId " +
                                        "GROUP BY v.Name, m.Name, m.Age " +
                                        "ORDER BY m.Name;";

            SqlCommand myCommand = new SqlCommand(takeVillainMinions, sqlConnection);
            myCommand.Parameters.AddWithValue("@VillainId", villainId);

            int counter = 1;

            using (SqlDataReader reader = myCommand.ExecuteReader())
            {
                while (reader.Read() == true)
                {
                    
                    string minionName = reader["Name"]?.ToString();
                    string age = reader["Age"]?.ToString();

                    if (minionName != "")
                    {
                        sb.AppendLine($"{counter}. {minionName} {age}");
                        counter++;
                    }
                    else
                    {
                        sb.AppendLine("(no minions)");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
