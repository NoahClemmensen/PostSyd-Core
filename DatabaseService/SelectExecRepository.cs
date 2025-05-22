using MySql.Data.MySqlClient;

namespace DatabaseService;

public class SelectExecRepository<T>(IEntityMapper<T> entityMapper)
    : Repository<T>(entityMapper, DatabaseConnection.SelectInstance)
{
    private readonly DatabaseConnection _execDbConnection = DatabaseConnection.ExecInstance;

    public async Task ExecuteProcedureAsync(IProcedureQueryObject queryObject)
    {
        if (!_execDbConnection.IsConnected()) return;

        await using var command = new MySqlCommand(queryObject.Query, _execDbConnection.Connection);
        command.Parameters.AddRange(queryObject.Parameters);

        try
        {
            await command.ExecuteReaderAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error executing procedure: {e.Message}");
        }
    }
}