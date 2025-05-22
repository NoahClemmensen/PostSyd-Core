namespace MVC_App.Models;

public class ChuteModel
{
    public int ChuteId { get; set; }
    public int? RouteId { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}