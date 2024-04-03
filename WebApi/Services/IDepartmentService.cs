using WebApi.Models;
using WebApi.Responses;
namespace WebApi.Services 
{
    public interface IDepartmentService
    {
        Response<List<Department>> GetAllDepartments(); 
        Response<Department> GetDepartmentById(int id);
        Response<string> AddDepartment(Department department);
        Response<string> UpdateDepartment(Department department);
        Response<bool> DeleteDepartment(int id);
    }
}
