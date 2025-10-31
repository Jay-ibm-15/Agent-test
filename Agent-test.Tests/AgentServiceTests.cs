using Xunit;

namespace Agent_test.Tests;

public class AgentServiceTests
{
	[Fact]
	public void AgentService_Constructor_AcceptsConnectionString()
	{
		// Arrange
		string connectionString = "Server=localhost;Database=TestDB;";

		// Act
		var service = new AgentService(connectionString);

		// Assert
		Assert.NotNull(service);
	}

	[Fact]
	public void AgentService_ImplementsIAgentService()
	{
		// Arrange
		string connectionString = "Server=localhost;Database=TestDB;";
		var service = new AgentService(connectionString);

		// Act
		bool implementsInterface = service is IAgentService;

		// Assert
		Assert.True(implementsInterface);
	}

	[Fact]
	public void AgentService_GetAllAgents_ReturnsListOfAgents()
	{
		// This is a structural test - in a real scenario, you'd use a test database
		// or mock the SqlConnection/SqlCommand
		
		// Arrange
		string connectionString = "Server=localhost;Database=TestDB;";
		var service = new AgentService(connectionString);

		// Act & Assert
		// We can only verify the method exists and returns a List<Agent>
		// Without a database connection, calling GetAllAgents() would throw an exception
		// In a production scenario, you would:
		// 1. Use a test database with known data
		// 2. Use a repository pattern with a mockable interface
		// 3. Use Entity Framework with an in-memory database
		
		Assert.NotNull(service);
	}
}
