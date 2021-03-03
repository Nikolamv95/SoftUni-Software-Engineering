using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace RemoveVillain
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

            string result = RemoveVillainById(sqlConnection, villainId);

            Console.WriteLine(result);
        }

        private static string RemoveVillainById(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            //This is how we open transaction "BeginTransaction" which later we will have to close with "Commit"
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            string takeVillainNameQueryTxt = "SELECT [Name] FROM Villains WHERE Id = @VillainId";

            using SqlCommand takeVillainNameCmd = new SqlCommand(takeVillainNameQueryTxt, sqlConnection);
            takeVillainNameCmd.Parameters.AddWithValue("@VillainId", villainId);
            
            //Every action should be connected to this transaction
            takeVillainNameCmd.Transaction = sqlTransaction;

            string villainName = takeVillainNameCmd.ExecuteScalar()?.ToString();

            if (villainName == null)
            {
                sb.AppendLine("No such villain was found.");
            }
            else
            {
                try
                {
                    string releaseMinionsQueryText = @"DELETE FROM MinionsVillains WHERE VillainId = @VillainId";

                    using SqlCommand releaseMinionsCmd = new SqlCommand(releaseMinionsQueryText, sqlConnection);
                    releaseMinionsCmd.Parameters.AddWithValue("@VillainId", villainId);

                    //Every action should be connected to this transaction
                    releaseMinionsCmd.Transaction = sqlTransaction;
                    int releasedMinionsCount = releaseMinionsCmd.ExecuteNonQuery();

                    string deleteVillainsQueryText = @"DELETE FROM Villains WHERE Id = @VillainId";
                    using SqlCommand deleteVillainsCmd = new SqlCommand(deleteVillainsQueryText, sqlConnection);
                    deleteVillainsCmd.Parameters.AddWithValue("@VillainId", villainId);

                    //Every action should be connected to this transaction
                    deleteVillainsCmd.Transaction = sqlTransaction;
                    deleteVillainsCmd.ExecuteNonQuery();

                    //Here we close the transaction with Commit
                    sqlTransaction.Commit();

                    sb.AppendLine($"{villainName} was deleted.");
                    sb.AppendLine($"{releasedMinionsCount} minions were released.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);

                    try
                    {
                        //If we have a problem in "Commit" step we have to Rollback. 
                        //Always do it in Try Catch block if an exception is thrown.
                        sqlTransaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {

                        sb.AppendLine(rollbackEx.Message);
                    }
                    
                }
            }

            return sb.ToString().Trim();
        }
    }
}
