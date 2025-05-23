namespace MVC_App.Models;

public class DepartmentModel
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public int PostalCode { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}