namespace MVC_App.Models;

public class DepartmentModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PostalCode { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}