using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class PackageLogMapper : IEntityMapper<PackageLogModel>
{
    public PackageLogModel MapFromReader(DbDataReader reader)
    {
        return new PackageLogModel
        {
            LogId = reader.GetInt32(reader.GetOrdinal("log_id")),
            PackageId = reader.IsDBNull(reader.GetOrdinal("package_id")) ? null : reader.GetInt32(reader.GetOrdinal("package_id")),
            FromStatusId = reader.IsDBNull(reader.GetOrdinal("from_status_id")) ? null : reader.GetInt32(reader.GetOrdinal("from_status_id")),
            ToStatusId = reader.IsDBNull(reader.GetOrdinal("to_status_id")) ? null : reader.GetInt32(reader.GetOrdinal("to_status_id")),
            FromRouteId = reader.IsDBNull(reader.GetOrdinal("from_route_id")) ? null : reader.GetInt32(reader.GetOrdinal("from_route_id")),
            ToRouteId = reader.IsDBNull(reader.GetOrdinal("to_route_id")) ? null : reader.GetInt32(reader.GetOrdinal("to_route_id")),
            Timestamp = reader.IsDBNull(reader.GetOrdinal("timestamp")) ? null : reader.GetDateTime(reader.GetOrdinal("timestamp"))
        };
    }
}