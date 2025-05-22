using MySql.Data.MySqlClient;

namespace DatabaseService;

// Repository pattern
public class Repository<T>(IEntityMapper<T> entityMapper, DatabaseConnection dbConnection) : IRepository<T>
{
    protected readonly DatabaseConnection DbConnection = dbConnection;
    
    public async Task<IEnumerable<T>> ExecuteQueryAsync(IQueryObject queryObject)
    {
        var result = new List<T>();
        if (!DbConnection.IsConnected()) return result;

        await using var command = new MySqlCommand(queryObject.Query, DbConnection.Connection);
        command.Parameters.AddRange(queryObject.Parameters);

        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            result.Add(entityMapper.MapFromReader(reader));
        }
        return result;
    }
}