namespace MVC_App.Models;

public class RouteModel
{
    public int RouteId { get; set; }
    public int? ToShopId { get; set; }
    public int? FromDepartmentId { get; set; }
    public string? Info { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}