using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class PackageMapper : IEntityMapper<PackageModel>
{
    public PackageModel MapFromReader(DbDataReader reader)
    {
        return new PackageModel
        {
            Id = reader.GetInt32(0),
            ShopId = reader.GetInt32(1),
            StatusId = reader.GetInt32(2),
            SenderName = reader.GetString(3),
            SenderPhone = reader.IsDBNull(4) ? null : reader.GetString(4),
            SenderEmail = reader.GetString(5),
            ReceiverName = reader.GetString(6),
            ReceiverPhone = reader.IsDBNull(7) ? null : reader.GetString(7),
            ReceiverEmail = reader.GetString(8),
            RouteId = reader.IsDBNull(9) ? null : (int?)reader.GetInt32(9),
            JSON = reader.IsDBNull(10) ? null : (object?)reader.GetValue(10),
            CreatedAt = reader.GetDateTime(11)
        };
    }
}