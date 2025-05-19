using System.Data.Common;
using DatabaseService;

namespace MVC_App.Models;

public class ShopMapper : IEntityMapper<ShopModel>
{
    public ShopModel MapFromReader(DbDataReader reader)
    {
        return new ShopModel
        {
            ShopId = reader.GetInt32(reader.GetOrdinal("shop_id")),
            ShopName = reader.GetString(reader.GetOrdinal("shop_name")),
            Address = reader.GetString(reader.GetOrdinal("address")),
            Info = reader.IsDBNull(reader.GetOrdinal("info")) ? null : reader.GetString(reader.GetOrdinal("info")),
            Deleted = reader.IsDBNull(reader.GetOrdinal("deleted")) ? null : reader.GetBoolean(reader.GetOrdinal("deleted")),
            CreatedDate = reader.IsDBNull(reader.GetOrdinal("created_date")) ? null : reader.GetDateTime(reader.GetOrdinal("created_date")),
            DeletedDate = reader.IsDBNull(reader.GetOrdinal("deleted_date")) ? null : reader.GetDateTime(reader.GetOrdinal("deleted_date"))
        };
    }
}