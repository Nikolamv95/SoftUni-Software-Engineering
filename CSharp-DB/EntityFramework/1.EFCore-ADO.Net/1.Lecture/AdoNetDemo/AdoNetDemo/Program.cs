using Microsoft.Data.SqlClient;
using System;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           ///Step 1 - open connection to the DataBase
            string connectionString = @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=SoftUniLec2;Integrated Security=true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                ///Step 2 - Do operations with the DataBase
                //VARIATION 1 - ExecuteScalar(). ExecuteScalar will return only 1 cell from the SQL Table. It`s very importat the command to ask a result which can be returned in one cell
                string selectCell = "SELECT COUNT (*) FROM [Employees]"; //Do something with the DB

                SqlCommand sqlCommand = new SqlCommand(selectCell, sqlConnection); //selectCell - operation with the DB, sqlConnection - DB Conenction
                object reader = sqlCommand.ExecuteScalar();//Read only one cell
                Console.WriteLine(reader);//Print result



                //VARIATION 2 - ExecuteRead()
                //ExecuteReader will read all the rows in the SQL Table.
                //It`s very importat the command to ask a result which can be returned as a table with data
                string selectTable = "SELECT [FirstName], [LastName], [Salary] FROM [Employees] WHERE FirstName LIKE 'N%'"; //Do something with the DB
                SqlCommand sqlCommand2 = new SqlCommand(selectTable, sqlConnection); //selectTable - operation with the DB, sqlConnection - DB Conenction

                ///Open reader which will read data from the table and will print it. After you are done reader2 has to be closed!!! We are doing that with using()
                ReadDataFromTheTable(sqlCommand2);


                //VARIATION 3 - ExecuteNonQuery()
                //We use this command when we will update, insert or do operation which will not return a result
                SqlCommand updateSalaryCommand = new SqlCommand("UPDATE Employees SET Salary = Salary * 1.10", sqlConnection);//Do something with the DB
                int updatedRows = updateSalaryCommand.ExecuteNonQuery();//ExecuteNonQuery returns result how many rows were affected
                Console.WriteLine($"Salary updated for {updatedRows} Employees");//Print result
                
                ///Like previous execution of the method
                ReadDataFromTheTable(sqlCommand2);


               // string villainname = myCommand.ExecuteScalar()?.ToString(); This operation with ? if don`t see nothing in the table will return null as a result in a string format
            }
        }

        private static void ReadDataFromTheTable(SqlCommand sqlCommand2)
        {
            ///Open reader which will read data from the table and will print it. After you are done reader2 has to be closed!!! We are doing that with using()
            using (SqlDataReader reader2 = sqlCommand2.ExecuteReader())
            {
                while (reader2.Read() == true)
                {
                    //We can access the columns by writing their names in the reader["name of the columns"], also we can do it with index reader[1], 
                    //but its not preffered. Also we have to cast the result in to the right C# data type.
                    string firstName = (string)reader2["FirstName"];
                    string lastName = (string)reader2["LastName"];
                    decimal salary = (decimal)reader2["Salary"];
                    Console.WriteLine($"{firstName} {lastName} - {salary:f2}");
                }
            }
        }
    }
}
