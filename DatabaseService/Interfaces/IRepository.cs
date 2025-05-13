using MySql.Data.MySqlClient;

namespace DatabaseService;

public interface IRepository<T>
{
    Task<IEnumerable<T>> ExecuteQueryAsync(IQueryObject queryObject);
}