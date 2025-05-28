using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class UserMapper : IEntityMapper<UserModel>
{
    public UserModel MapFromReader(DbDataReader reader)
    {
        return new UserModel
        {
            Username = reader.GetString(0),
            Password = reader.IsDBNull(1) ? null : reader.GetString(1),
            DepartmentId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
            Deleted = reader.GetBoolean(3),
            CreatedDate = reader.GetDateTime(4),
            DeletedDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
        };
    }
}