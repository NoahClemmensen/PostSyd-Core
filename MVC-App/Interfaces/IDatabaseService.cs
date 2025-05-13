using MVC_App.Models;

namespace MVC_App.Interfaces;

public interface IDatabaseService
{
    Task<IEnumerable<DepartmentModel>> GetDepartments();
    Task<DepartmentModel?> GetDepartmentById(int id);
}