using DatabaseService;
using DatabaseService.Queries;
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

    public void SetConnection(string server, string schema, string user, string password)
    {
        DatabaseConnection.Instance.SetConnectionDetails(server, schema, user, password);
    }

    public void CloseConnection()
    {
        DatabaseConnection.Instance.Close();
    }
}