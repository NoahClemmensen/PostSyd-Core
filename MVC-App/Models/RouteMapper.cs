using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class RouteMapper : IEntityMapper<RouteModel>
{
    public RouteModel MapFromReader(DbDataReader reader)
    {
        return new RouteModel
        {
            RouteId = reader.GetInt32(reader.GetOrdinal("route_id")),
            ToShopId = reader.IsDBNull(reader.GetOrdinal("to_shop_id")) ? null : reader.GetInt32(reader.GetOrdinal("to_shop_id")),
            FromDepartmentId = reader.IsDBNull(reader.GetOrdinal("from_department_id")) ? null : reader.GetInt32(reader.GetOrdinal("from_department_id")),
            Info = reader.IsDBNull(reader.GetOrdinal("info")) ? null : reader.GetString(reader.GetOrdinal("info")),
            Deleted = reader.GetBoolean(reader.GetOrdinal("deleted")),
            CreatedDate = reader.GetDateTime(reader.GetOrdinal("created_date")),
            DeletedDate = reader.IsDBNull(reader.GetOrdinal("deleted_date")) ? null : reader.GetDateTime(reader.GetOrdinal("deleted_date"))
        };
    }
}