using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DatabaseService;

// Data mapper pattern
public interface IEntityMapper<T>
{
    T MapFromReader(DbDataReader reader);
}