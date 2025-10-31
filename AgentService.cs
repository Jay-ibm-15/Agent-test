using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Agent_test
{
	public class Agent
	{
		public int Id { get; set; }
		public string AgentName { get; set; } = string.Empty;

		public override string ToString()
		{
			return $"Id: {Id}, Name: {AgentName}";
		}
	}

	public interface IAgentService
	{
		List<Agent> GetAllAgents();
	}

	public class AgentService : IAgentService
	{
		private readonly string _connectionString;

		public AgentService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<Agent> GetAllAgents()
		{
			var agents = new List<Agent>();

			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				conn.Open();
				string selectQuery = "SELECT Id, AgentName FROM TblAgent";
				using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						agents.Add(new Agent
						{
							Id = Convert.ToInt32(reader["Id"]),
							AgentName = reader["AgentName"].ToString() ?? string.Empty
						});
					}
				}
			}

			return agents;
		}
	}
}
