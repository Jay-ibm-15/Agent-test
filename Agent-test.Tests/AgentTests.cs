using Xunit;

namespace Agent_test.Tests;

public class AgentTests
{
	[Fact]
	public void Agent_Constructor_SetsDefaultValues()
	{
		// Arrange & Act
		var agent = new Agent();

		// Assert
		Assert.Equal(0, agent.Id);
		Assert.Equal(string.Empty, agent.AgentName);
	}

	[Fact]
	public void Agent_Properties_CanBeSet()
	{
		// Arrange
		var agent = new Agent();

		// Act
		agent.Id = 1;
		agent.AgentName = "TestAgent";

		// Assert
		Assert.Equal(1, agent.Id);
		Assert.Equal("TestAgent", agent.AgentName);
	}

	[Fact]
	public void Agent_ToString_ReturnsFormattedString()
	{
		// Arrange
		var agent = new Agent
		{
			Id = 123,
			AgentName = "Agent007"
		};

		// Act
		string result = agent.ToString();

		// Assert
		Assert.Equal("Id: 123, Name: Agent007", result);
	}

	[Theory]
	[InlineData(1, "Alpha")]
	[InlineData(999, "BetaAgent")]
	[InlineData(0, "")]
	public void Agent_ToString_WorksWithVariousValues(int id, string name)
	{
		// Arrange
		var agent = new Agent
		{
			Id = id,
			AgentName = name
		};

		// Act
		string result = agent.ToString();

		// Assert
		Assert.Equal($"Id: {id}, Name: {name}", result);
	}
}
