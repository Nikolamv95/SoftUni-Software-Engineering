using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTownNamesCasing
{
    class StartUp
    {
        private const string ConnectionMinionsDB2 =
                           @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();

            string countryName = Console.ReadLine();

            string result = ChangeUpperCaseTownLetters(sqlConnection, countryName);

            Console.WriteLine(result);
        }

        private static string ChangeUpperCaseTownLetters(SqlConnection sqlConnection, string countryName)
        {
            StringBuilder sb = new StringBuilder();
            List<string> listTowns = new List<string>();

            //Take CountryID
            string takeCountryIdQueryTxt = @"SELECT Id FROM Countries WHERE [Name] = @CountryName";
            using SqlCommand takeCountryIdCmd = new SqlCommand(takeCountryIdQueryTxt, sqlConnection);
            takeCountryIdCmd.Parameters.AddWithValue("@CountryName", countryName);
            int countryId = (int)takeCountryIdCmd.ExecuteScalar();

            //Take Town names from CountryID
            string takeTownsFromCountryQueryTxt = @"SELECT [Name] FROM Towns WHERE CountryCode = @CountryId";
            using SqlCommand takeCountryTownsCmd = new SqlCommand(takeTownsFromCountryQueryTxt, sqlConnection);
            takeCountryTownsCmd.Parameters.AddWithValue("@CountryId", countryId);
            using SqlDataReader reader = takeCountryTownsCmd.ExecuteReader();
            {
                while (reader.Read() == true)
                {
                    string townName = (string)reader["Name"];
                    listTowns.Add(townName);
                }

                reader.Close();
            }
            

            if ((listTowns.Count > 0) && (listTowns[0] != ""))
            {
                //Update table town names for CountryId

                int numOfTownsAffected = 0;
                numOfTownsAffected = UpdateTwonNames(sqlConnection, listTowns, numOfTownsAffected);

                sb.AppendLine($"{numOfTownsAffected} town names were affected.");

                for (int i = 0; i < listTowns.Count; i++)
                {
                    if (i == 0)
                    {
                        sb.Append($"[{listTowns[i].ToUpper()}, ");
                    }
                    else if (i > 0 && i < listTowns.Count - 1)
                    {
                        sb.Append($"{listTowns[i].ToUpper()}, ");
                    }
                    else
                    {
                        sb.Append($"{listTowns[i].ToUpper()}]");
                    }

                }
            }
            else
            {
                sb.AppendLine("No town names were affected.");
            }

            return sb.ToString().Trim();
        }

        private static int UpdateTwonNames(SqlConnection sqlConnection, List<string> listTowns, int numOfTownsAffected)
        {
            for (int i = 0; i < listTowns.Count; i++)
            {
                string oldName = listTowns[i];
                string newName = listTowns[i].ToUpper();

                string updateTownNameQueryTxt = @"UPDATE Towns 
                                                SET [Name] = @NewName 
                                                WHERE [Name] = @OldName";

                using SqlCommand updateTownNameCmd = new SqlCommand(updateTownNameQueryTxt, sqlConnection);
                updateTownNameCmd.Parameters.AddWithValue("@NewName", newName);
                updateTownNameCmd.Parameters.AddWithValue("@OldName", oldName);
                numOfTownsAffected += updateTownNameCmd.ExecuteNonQuery();
            }

            return numOfTownsAffected;
        }
    }
}
