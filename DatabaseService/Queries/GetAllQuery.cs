using MySql.Data.MySqlClient;

namespace DatabaseService.Queries;

public class GetAllQuery(string tableName) : IQueryObject
{
    public string Query { get; } = $"SELECT * FROM {tableName}";
    public MySqlParameter[] Parameters { get; } = [];
}