using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("/api/Employee/")]
public class EmployeeController(IEmployeeService employeeService):ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService;

    [HttpGet]
    public Response<List<Employee>> GetEmployees()
    {
        return _employeeService.GetEmployee();
    }
    
    [HttpGet("{EmployeeId:int}")]
    public Response<Employee> GetEmployeeById(int employeeId)
    {
        return _employeeService.GetEmployeeById(employeeId);
    }
    
    [HttpPost]
    public Response<string> Add(Employee employee)
    {
        return _employeeService.AddEmployee(employee);
    }
    [HttpPut]
    public Response<string> Update(Employee employee)
    {
        return _employeeService.UpdateEmployee(employee);
    }
    [HttpDelete("{EmployeeId:int}")]
    public Response<bool> Delete(int employeeId)
    {
        return _employeeService.DeleteEmployee(employeeId);
    }
}