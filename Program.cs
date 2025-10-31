
using System;
using Microsoft.Data.SqlClient;

class Program
{
	static string connectionString = @"Data Source=IBM-2J3XNC4\SQLEXPRESS;Initial Catalog=AgentTest;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

	static void Main()
	{
		// Retrieve all agents
		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			conn.Open();
			string selectQuery = "SELECT Id, AgentName FROM TblAgent";
			using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				Console.WriteLine("Agents:");
				while (reader.Read())
				{
					Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["AgentName"]}");
				}
			}
		}
	}
}
