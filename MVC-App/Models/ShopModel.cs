namespace MVC_App.Models;

public class ShopModel
{
    public int ShopId { get; set; }
    public string ShopName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Info { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}