using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class ChuteMapper : IEntityMapper<ChuteModel>
{
    public ChuteModel MapFromReader(DbDataReader reader)
    {
        return new ChuteModel
        {
            ChuteId = reader.GetInt32(reader.GetOrdinal("chute_id")),
            RouteId = reader.IsDBNull(reader.GetOrdinal("route_id")) ? null : reader.GetInt32(reader.GetOrdinal("route_id")),
            Deleted = reader.IsDBNull(reader.GetOrdinal("deleted")) ? null : reader.GetBoolean(reader.GetOrdinal("deleted")),
            CreatedDate = reader.IsDBNull(reader.GetOrdinal("created_date")) ? null : reader.GetDateTime(reader.GetOrdinal("created_date")),
            DeletedDate = reader.IsDBNull(reader.GetOrdinal("deleted_date")) ? null : reader.GetDateTime(reader.GetOrdinal("deleted_date"))
        };
    }
}