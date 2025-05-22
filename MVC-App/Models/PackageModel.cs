namespace MVC_App.Models;

public class PackageModel
{
    public int PackageId { get; set; }
    public int ShopId { get; set; }
    public int StatusId { get; set; }
    public string SenderName { get; set; }
    public string? SenderPhone { get; set; }
    public string SenderEmail { get; set; }
    public string ReceiverName { get; set; }
    public string? ReceiverPhone { get; set; }
    public string ReceiverEmail { get; set; }
    public int? RouteId { get; set; }
    public object? JSON { get; set; }
    public DateTime CreatedAt { get; set; }
}