using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;
using System.Net;

namespace WebApi.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DapperContext _context;
        public DepartmentService()
        {
            _context = new DapperContext();
        }
        public Response<string> AddDepartment(Department department)
        {
            try
            {
                var sql = $"insert into department(name)values('{department.Name}') ";
                var result = _context.Connection().Execute(sql);
                if (result>0)
                {
                    return new Response<string>("Department succesfully added");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "could not create department ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Response<bool> DeleteDepartment(int id)
        {
            try
            {
                var sql = $"Delete from department where id={@id}"; 
                var result=_context.Connection().Execute(sql);
                if (result>0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, "Department was not found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
            }
        }

        public Response<List<Department>> GetAllDepartments()
        {
            var sql = "Select * from department";
            var result= _context.Connection().Query<Department>(sql).ToList();
            return new Response<List<Department>>(result);
        }

        public Response<Department> GetDepartmentById(int id)
        {
            try
            {
                var sql = $"Select * from department where id={@id}";
                var result = _context.Connection().QueryFirstOrDefault(sql);
                if (result != null)
                {
                    return new Response<Department>(result);
                }
                return new Response<Department>(HttpStatusCode.BadRequest, "Department not found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return new Response<Department>(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        public Response<string> UpdateDepartment(Department department)
        {
            try
            {
                var sql = $"update department set name='{department.Name}' where id={department.Id}"; 
                var result=_context.Connection().Execute(sql);
                if (result>0)
                {
                    return new Response<string>("Department updated");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Could not update department");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
            }
        }
    }
}
