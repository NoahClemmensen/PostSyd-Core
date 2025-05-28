namespace MVC_App.Models;

public class ChuteModel(
    int chuteId = 0,
    int? routeId = null,
    bool? deleted = null,
    DateTime? createdDate = null,
    DateTime? deletedDate = null)
{
    public int ChuteId { get; set; } = chuteId;
    public int? RouteId { get; set; } = routeId;
    public bool? Deleted { get; set; } = deleted;
    public DateTime? CreatedDate { get; set; } = createdDate;
    public DateTime? DeletedDate { get; set; } = deletedDate;
}