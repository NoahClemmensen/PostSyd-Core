using MVC_App.Models;

namespace MVC_App.Interfaces;

public interface IPackageRoutingService
{
    Task<ChuteModel?> GetNextChute(PackageModel package, DepartmentModel currentDepartment);
}