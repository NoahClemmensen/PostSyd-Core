using MVC_App.Models;

namespace MVC_App.Interfaces;

public interface IDatabaseService
{
    Task<IEnumerable<DepartmentModel>> GetDepartments();
    Task<DepartmentModel?> GetDepartmentById(int id);
    
    Task<IEnumerable<PackageModel>> GetPackages();
    Task<PackageModel?> GetPackageById(int id);
    
    Task<IEnumerable<RouteModel>> GetRoutes();
    Task<RouteModel?> GetRouteById(int id);
    
    Task<IEnumerable<ShopModel>> GetShops();
    Task<ShopModel?> GetShopById(int id);
    
    Task<IEnumerable<PackageLogModel>> GetPackageLogs();
    Task<PackageLogModel?> GetPackageLogById(int id);
}