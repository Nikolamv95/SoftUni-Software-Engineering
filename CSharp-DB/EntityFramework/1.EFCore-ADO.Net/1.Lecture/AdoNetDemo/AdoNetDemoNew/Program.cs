using Microsoft.Data.SqlClient;
using System;

namespace AdoNetDemoNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type FristName...");
            string firstName = Console.ReadLine();
            Console.WriteLine("Type JobTitle...");
            string jobTitle = Console.ReadLine();

            ///Step 1 - open connection to the DataBase
            string connectionString = @"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=SoftUniLec2;Integrated Security=true";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                ///Never do this type of concatenation and reading input data from outside the app
                //string sqlOperation = "SELECT COUNT(*) FROM Employees WHERE [FirstName] = '" + firstName + "' AND [JobTitle] = '" + jobTitle + "';";

                ///Use this option withouth concatenation
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT COUNT(*) FROM Employees " +
                    "WHERE [FirstName] = @FirstName " +
                    "AND [JobTitle] = @JobTitle", sqlConnection);//Do something with DB

                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);//Add Parameter
                sqlCommand.Parameters.AddWithValue("@JobTitle", jobTitle);//Add Parameter

                int usersCount = (int)sqlCommand.ExecuteScalar();//Get result

                if (usersCount > 0)
                {
                    Console.WriteLine($"Num of Users Count is {usersCount}.");
                    Console.WriteLine($"Welcome {firstName}.");
                }
                else
                {
                    Console.WriteLine("Access forbidden.");
                }


                //Example 2
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Projects " +
                    "(Name, Description, StartDate, EndDate) VALUES " +
                    "(@name, @desc, @start, @end)", sqlConnection);

                Console.WriteLine("Add name");
                string name = Console.ReadLine();
                string description = Console.ReadLine();
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);

                int rowsAffecteed = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffecteed);


            }
        }
    }
}






