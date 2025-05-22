using MVC_App.Models;

namespace MVC_App.Interfaces;

public interface IDatabaseService
{
    Task<IEnumerable<DepartmentModel>> GetDepartments();
    Task<DepartmentModel?> GetDepartmentById(int id);
    
    Task<IEnumerable<PackageModel>> GetPackages();
    Task<PackageModel?> GetPackageById(int id);
    Task UpdateRouteOnPackage(int packageId, int routeId);
    
    Task<IEnumerable<RouteModel>> GetRoutes();
    Task<RouteModel?> GetRouteById(int id);
    Task CreateRoute(int shopId, int departmentId, string? json);
    Task<IEnumerable<RouteModel>> GetRoutesByShopId(int shopId);
    
    Task<IEnumerable<ShopModel>> GetShops();
    Task<ShopModel?> GetShopById(int id);
    
    Task<IEnumerable<PackageLogModel>> GetPackageLogs();
    Task<PackageLogModel?> GetPackageLogById(int id);
    
    Task<ChuteModel?> GetChuteById(int id);
    Task<IEnumerable<ChuteModel>> GetChuteByRouteId(int id);
}