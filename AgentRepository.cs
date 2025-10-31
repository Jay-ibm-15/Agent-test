using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

public class AgentRepository
{
    private readonly string _connectionString;
    private readonly HttpClient _httpClient;

    public AgentRepository(string connectionString)
    {
        _connectionString = connectionString;
        _httpClient = new HttpClient();
    }

    public async Task<List<Agent>> GetAgentsFromDbAsync()
    {
        var agents = new List<Agent>();
        using (var conn = new SqlConnection(_connectionString))
        {
            await conn.OpenAsync();
            var cmd = new SqlCommand("SELECT Id, AgentName FROM TblAgent", conn);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    agents.Add(new Agent
                    {
                        Id = reader.GetString(0),
                        AgentName = reader.GetString(1)
                    });
                }
            }
        }
        return agents;
    }

    public async Task<string> GetApiResponseAsync(string apiUrl)
    {
        var response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
