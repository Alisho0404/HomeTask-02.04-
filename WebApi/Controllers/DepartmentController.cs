using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/Department/")]
    public class DepartmentController(IDepartmentService departmentService) : ControllerBase
    {
        private readonly IDepartmentService _departmentService = departmentService;
        [HttpGet]
        public Response<List<Department>> GetDepartment()
        {
            return _departmentService.GetAllDepartments();
        }

        [HttpGet("{departmentId:int}")]
        public Response<Department> GetdepartmentById(int departmentId)
        {
            return _departmentService.GetDepartmentById(departmentId);
        }

        [HttpPost]
        public Response<string> Add(Department department)
        {
            return _departmentService.AddDepartment(department);
        }
        [HttpPut]
        public Response<string> Update(Department department)
        {
            return _departmentService.UpdateDepartment(department);
        }
        [HttpDelete("{departmentId:int}")]
        public Response<bool> Delete(int departmentId)
        {
            return _departmentService.DeleteDepartment(departmentId);
        }

    }
}
