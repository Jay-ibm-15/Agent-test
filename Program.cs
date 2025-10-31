using System;
using Agent_test;

class Program
{
	static string connectionString = @"Data Source=IBM-2J3XNC4\SQLEXPRESS;Initial Catalog=AgentTest;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";

	static void Main()
	{
		var agentService = new AgentService(connectionString);
		var agents = agentService.GetAllAgents();

		Console.WriteLine("Agents:");
		foreach (var agent in agents)
		{
			Console.WriteLine(agent);
		}
	}
}
