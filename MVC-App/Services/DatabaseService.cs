using DatabaseService;
using DatabaseService.Queries;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;
using MVC_App.Models;

namespace MVC_App.Services;

public class DatabaseService : IDatabaseService
{
    public async Task<IEnumerable<DepartmentModel>> GetDepartments()
    {
        var dataMapper = new DepartmentMapper();
        var repository = new Repository<DepartmentModel>(dataMapper);
        var queryObject = new GetAllQuery("departments");
        return await repository.ExecuteQueryAsync(queryObject);
    }
    
    public async Task<DepartmentModel?> GetDepartmentById(int id)
    {
        var dataMapper = new DepartmentMapper();
        var repository = new Repository<DepartmentModel>(dataMapper);
        var queryObject = new GetByIdQuery("departments", id, "department_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<PackageModel>> GetPackages()
    {
        var dataMapper = new PackageMapper();
        var repository = new Repository<PackageModel>(dataMapper);
        var queryObject = new GetAllQuery("packages");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<PackageModel?> GetPackageById(int id)
    {
        var dataMapper = new PackageMapper();
        var repository = new Repository<PackageModel>(dataMapper);
        var queryObject = new GetByIdQuery("packages", id, "package_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
    
    public async Task<IEnumerable<RouteModel>> GetRoutes()
    {
        var dataMapper = new RouteMapper();
        var repository = new Repository<RouteModel>(dataMapper);
        var queryObject = new GetAllQuery("routes");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<RouteModel?> GetRouteById(int id)
    {
        var dataMapper = new RouteMapper();
        var repository = new Repository<RouteModel>(dataMapper);
        var queryObject = new GetByIdQuery("routes", id, "route_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
    
    public async Task<IEnumerable<ShopModel>> GetShops()
    {
        var dataMapper = new ShopMapper();
        var repository = new Repository<ShopModel>(dataMapper);
        var queryObject = new GetAllQuery("shops");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<ShopModel?> GetShopById(int id)
    {
        var dataMapper = new ShopMapper();
        var repository = new Repository<ShopModel>(dataMapper);
        var queryObject = new GetByIdQuery("shops", id, "shop_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
    
    public async Task<IEnumerable<PackageLogModel>> GetPackageLogs()
    {
        var dataMapper = new PackageLogMapper();
        var repository = new Repository<PackageLogModel>(dataMapper);
        var queryObject = new GetAllQuery("package_log");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<PackageLogModel?> GetPackageLogById(int id)
    {
        var dataMapper = new PackageLogMapper();
        var repository = new Repository<PackageLogModel>(dataMapper);
        var queryObject = new GetByIdQuery("package_log", id, "log_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
}