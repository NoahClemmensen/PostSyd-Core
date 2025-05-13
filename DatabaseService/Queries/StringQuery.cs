using MySql.Data.MySqlClient;

namespace DatabaseService.Queries;

public class StringQuery(string query, params MySqlParameter[] parameters) : IQueryObject
{
    public string Query { get; } = query;
    public MySqlParameter[] Parameters { get; } = parameters;
}