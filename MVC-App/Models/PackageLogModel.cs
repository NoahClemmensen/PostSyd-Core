namespace MVC_App.Models;

public class PackageLogModel
{
    public int LogId { get; set; }
    public int? PackageId { get; set; }
    public int? FromStatusId { get; set; }
    public int? ToStatusId { get; set; }
    public int? FromRouteId { get; set; }
    public int? ToRouteId { get; set; }
    public DateTime? Timestamp { get; set; }
}