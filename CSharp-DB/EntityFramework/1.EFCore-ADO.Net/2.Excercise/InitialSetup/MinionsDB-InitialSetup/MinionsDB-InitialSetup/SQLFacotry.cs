
using Microsoft.Data.SqlClient;
using System;

namespace MinionsDB_InitialSetup
{

    public class SQLFacotry
    {
        private const string ConnectionString = @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=Master;Integrated Security=true;";
        private const string ConnectionMinionsDB2 = @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=MinionsDB2;Integrated Security=true;";

        public void CreateDataBase(string createDatabase)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand myCommand = new SqlCommand(createDatabase, sqlConnection);

            try
            {
                sqlConnection.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("DataBase is Created Successfully");
            }
            catch (Exception)
            {
                throw new Exception("Program faild to create DataBase!");
            }
        }

        public void CreateTable(string tableToCreate)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            SqlCommand myCommand = new SqlCommand(tableToCreate, sqlConnection);

            try
            {
                sqlConnection.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("Table has been Created Successfully");
            }
            catch (Exception)
            {
                throw new Exception("Program faild to create the table!");
            }
        }

        public void InsertIntoTable(string insertValues)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionMinionsDB2);
            SqlCommand myCommand = new SqlCommand(insertValues, sqlConnection);

            try
            {
                sqlConnection.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("Values has been inserted Successfully");
            }
            catch (Exception)
            {
                throw new Exception("Program faild to insert new values!");
            }

        }
    }
}
