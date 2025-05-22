using DatabaseService;
using DatabaseService.Queries;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Interfaces;
using MVC_App.Models;
using MySql.Data.MySqlClient;

namespace MVC_App.Services;

public class DatabaseService : IDatabaseService
{
    public async Task<IEnumerable<DepartmentModel>> GetDepartments()
    {
        var dataMapper = new DepartmentMapper();
        var repository = new SelectExecRepository<DepartmentModel>(dataMapper);
        var queryObject = new GetAllQuery("departments");
        return await repository.ExecuteQueryAsync(queryObject);
    }
    
    public async Task<DepartmentModel?> GetDepartmentById(int id)
    {
        var dataMapper = new DepartmentMapper();
        var repository = new SelectExecRepository<DepartmentModel>(dataMapper);
        var queryObject = new GetByIdQuery("departments", id, "department_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<PackageModel>> GetPackages()
    {
        var dataMapper = new PackageMapper();
        var repository = new SelectExecRepository<PackageModel>(dataMapper);
        var queryObject = new GetAllQuery("packages");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<PackageModel?> GetPackageById(int id)
    {
        var dataMapper = new PackageMapper();
        var repository = new SelectExecRepository<PackageModel>(dataMapper);
        var queryObject = new GetByIdQuery("packages", id, "package_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
    
    public async Task UpdateRouteOnPackage(int packageId, int routeId) 
    {
        var dataMapper = new PackageMapper();
        var repository = new SelectExecRepository<PackageModel>(dataMapper);

        var queryObject = new ExecuteProcedureQuery(
            "update_route_on_package",
            [
                new MySqlParameter("@in_package_id", packageId),
                new MySqlParameter("@in_route_id", routeId)
            ]
        );
        
        await repository.ExecuteProcedureAsync(queryObject);
    }
    
    public async Task<IEnumerable<RouteModel>> GetRoutes()
    {
        var dataMapper = new RouteMapper();
        var repository = new SelectExecRepository<RouteModel>(dataMapper);
        var queryObject = new GetAllQuery("routes");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<RouteModel?> GetRouteById(int id)
    {
        var dataMapper = new RouteMapper();
        var repository = new SelectExecRepository<RouteModel>(dataMapper);
        var queryObject = new GetByIdQuery("routes", id, "route_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
    
    public Task<IEnumerable<RouteModel>> GetRoutesByShopId(int shopId)
    {
        var dataMapper = new RouteMapper();
        var repository = new SelectExecRepository<RouteModel>(dataMapper);
        var queryObject = new GetByIdQuery("routes", shopId, "to_shop_id");
        return repository.ExecuteQueryAsync(queryObject);
    }
    
    public async Task CreateRoute(int shopId, int departmentId, string? json)
    {
        var dataMapper = new RouteMapper();
        var repository = new SelectExecRepository<RouteModel>(dataMapper);

        var queryObject = new ExecuteProcedureQuery(
            "create_route",
            [
                new MySqlParameter("@in_to_shop_id", shopId),
                new MySqlParameter("@in_from_department_id", departmentId),
                new MySqlParameter("@in_info", json ?? (object)DBNull.Value)
            ]
        );

        await repository.ExecuteProcedureAsync(queryObject);
    }

    public async Task<IEnumerable<ShopModel>> GetShops()
    {
        var dataMapper = new ShopMapper();
        var repository = new SelectExecRepository<ShopModel>(dataMapper);
        var queryObject = new GetAllQuery("shops");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<ShopModel?> GetShopById(int id)
    {
        var dataMapper = new ShopMapper();
        var repository = new SelectExecRepository<ShopModel>(dataMapper);
        var queryObject = new GetByIdQuery("shops", id, "shop_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }
    
    public async Task<IEnumerable<PackageLogModel>> GetPackageLogs()
    {
        var dataMapper = new PackageLogMapper();
        var repository = new SelectExecRepository<PackageLogModel>(dataMapper);
        var queryObject = new GetAllQuery("package_log");
        return await repository.ExecuteQueryAsync(queryObject);
    }

    public async Task<PackageLogModel?> GetPackageLogById(int id)
    {
        var dataMapper = new PackageLogMapper();
        var repository = new SelectExecRepository<PackageLogModel>(dataMapper);
        var queryObject = new GetByIdQuery("package_log", id, "log_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }

    public async Task<ChuteModel?> GetChuteById(int id)
    {
        var dataMapper = new ChuteMapper();
        var repository = new SelectExecRepository<ChuteModel>(dataMapper);
        var queryObject = new GetByIdQuery("chutes", id, "chute_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<ChuteModel>> GetChuteByRouteId(int id)
    {
        var dataMapper = new ChuteMapper();
        var repository = new SelectExecRepository<ChuteModel>(dataMapper);
        var queryObject = new GetByIdQuery("chutes", id, "route_id");
        var result = await repository.ExecuteQueryAsync(queryObject);
        return result.ToList();
    }
}