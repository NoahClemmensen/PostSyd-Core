using MySql.Data.MySqlClient;

namespace DatabaseService.Queries;

public class GetByColumnQuery(string tableName, object value, string columnName) : IQueryObject
{
    public string Query { get; } = $"SELECT * FROM {tableName} WHERE {columnName} = @value";
    public MySqlParameter[] Parameters { get; } =
    [
        new("@value", value)
    ];
}