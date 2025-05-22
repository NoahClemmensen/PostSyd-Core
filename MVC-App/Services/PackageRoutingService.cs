using MVC_App.Interfaces;
using MVC_App.Models;

namespace MVC_App.Services;

public class PackageRoutingService(IDatabaseService databaseService) : IPackageRoutingService
{
    private const int UnroutedPackageChuteId = 3;

    public async Task<ChuteModel?> GetNextChute(PackageModel package, DepartmentModel currentDepartment)
    {
        if (package.RouteId == null)
        {
            var existingRoute = await FindExistingRoute(package.ShopId, currentDepartment.DepartmentId);
            
            // Send it off to the unrouted chute if no route is found
            if (existingRoute == null) return await databaseService.GetChuteById(UnroutedPackageChuteId);
            
            await databaseService.UpdateRouteOnPackage(package.PackageId, existingRoute.RouteId); // Remember to update the package with the new route
            return await GetFirstOrDefaultChuteByRouteId(existingRoute.RouteId);
        }
        
        var route = await databaseService.GetRouteById((int)package.RouteId!);
        if (route == null)
        {
            return null;
        }

        return await GetFirstOrDefaultChuteByRouteId(route.RouteId);
    }
    
    private async Task<RouteModel?> FindExistingRoute(int toShopId, int fromDepartmentId)
    {
        var routes = await databaseService.GetRoutesByShopId(toShopId);
        return routes.FirstOrDefault(r => r.FromDepartmentId == fromDepartmentId);
    }

    private async Task<ChuteModel?> GetFirstOrDefaultChuteByRouteId(int routeId)
    {
        var chutes = await databaseService.GetChuteByRouteId(routeId);
        return chutes.FirstOrDefault();
    }
}