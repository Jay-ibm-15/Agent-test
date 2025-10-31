
using System;
using System.Threading.Tasks;

class Program
{
	static async Task Main()
	{
		string connectionString = @"Data Source=IBM-2J3XNC4\SQLEXPRESS;Initial Catalog=AgentTest;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;";
		var repo = new AgentRepository(connectionString);

		// Get agents from DB
		var agents = await repo.GetAgentsFromDbAsync();
		foreach (var agent in agents)
		{
			Console.WriteLine($"Id: {agent.Id}, Name: {agent.AgentName}");
		}

		string apiUrl = "https://jsonplaceholder.typicode.com/users";
		var apiResponse = await repo.GetApiResponseAsync(apiUrl);
		Console.WriteLine("API Response:");
		Console.WriteLine(apiResponse);
	}
}
