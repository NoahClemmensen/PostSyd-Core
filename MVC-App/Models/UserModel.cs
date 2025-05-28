namespace MVC_App.Models;

public class UserModel
{
    public string Username { get; set; }
    public string? Password { get; set; }
    public int? DepartmentId { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}