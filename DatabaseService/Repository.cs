using MySql.Data.MySqlClient;

namespace DatabaseService;

// Repsotiory pattern
public class Repository<T>(IEntityMapper<T> entityMapper) : IRepository<T>
{
    private readonly DatabaseConnection _dbConnection = DatabaseConnection.Instance;

    public async Task<IEnumerable<T>> ExecuteQueryAsync(IQueryObject queryObject)
    {
        var result = new List<T>();
        if (!_dbConnection.IsConnected()) return result;

        await using var command = new MySqlCommand(queryObject.Query, _dbConnection.Connection);
        command.Parameters.AddRange(queryObject.Parameters);

        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            result.Add(entityMapper.MapFromReader(reader));
        }
        return result;
    }
}