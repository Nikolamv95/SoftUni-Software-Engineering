using Microsoft.Data.SqlClient;
using System;

namespace MinionNamesV2
{
    class StartUp
    {
        private const string ConnectionMinionsDB2 =
                            @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            sqlConnection.Open();


        }
    }
}
