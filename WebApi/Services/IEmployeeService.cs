using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public interface IEmployeeService
{
    Response<List<Employee>> GetEmployee();
    Response<Employee> GetEmployeeById(int id);
    Response<string> AddEmployee(Employee employee);
    Response<string> UpdateEmployee(Employee employee);
    Response<bool> DeleteEmployee(int id);
}