using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class DepartmentMapper : IEntityMapper<DepartmentModel>
{
    public DepartmentModel MapFromReader(DbDataReader reader)
    {
        return new DepartmentModel
        {
            DepartmentId = reader.GetInt32(0),
            Name = reader.GetString(1),
            PostalCode = reader.GetInt32(2),
            Deleted = reader.GetBoolean(3),
            CreatedAt = reader.GetDateTime(4),
            DeletedAt = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
        };
    }
}