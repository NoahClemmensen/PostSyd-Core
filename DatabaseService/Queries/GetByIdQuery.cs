using MySql.Data.MySqlClient;

namespace DatabaseService.Queries;

public class GetByIdQuery(string tableName, int id, string idColumnName = "Id") : IQueryObject
{
    public string Query { get; } = $"SELECT * FROM {tableName} WHERE {idColumnName} = @Id";
    public MySqlParameter[] Parameters { get; } =
    [
        new("@Id", id)
    ];
}