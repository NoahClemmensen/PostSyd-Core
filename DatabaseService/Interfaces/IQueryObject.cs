using MySql.Data.MySqlClient;

namespace DatabaseService;

public interface IQueryObject
{
    string Query { get; }
    MySqlParameter[] Parameters { get; }
}