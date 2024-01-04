using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string server = "your_server_name.database.windows.net";
        string database = "your_database_name";
        string username = "your_username";
        string password = "your_password";

        string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM YourTableName";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Column1"]}, {reader["Column2"]}, ...");
                }

                reader.Close();
            }
        }
    }
}

