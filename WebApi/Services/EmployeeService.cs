using System.Net;
using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DapperContext _context;

    public EmployeeService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<Employee>> GetEmployee()
    {
        try
        {
            var sql = @"SELECT * FROM employee";
            var result = _context.Connection().Query<Employee>(sql).ToList();
            return new Response<List<Employee>>(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<List<Employee>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }


    public Response<Employee> GetEmployeeById(int id)
    {
        try
        {
            var sql = @$"SELECT * FROM employee where id={@id}";
            var result = _context.Connection().QueryFirstOrDefault<Employee>(sql);
            if (result != null) return new Response<Employee>(result);
            return new Response<Employee>(HttpStatusCode.BadRequest, "Employee not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<Employee>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<string> AddEmployee(Employee employee)
    {
        try
        {
            var sql = $"insert into employee(firstname,lastname,age,position,address,email,companyid,departmentid)" +
                $"values('{employee.FirstName}','{employee.LastName}',{employee.Age} ,'{employee.Position}','{employee.Address}'," +
                $"'{employee.Email}',{employee.CompanyId},{employee.DepartmentId})";
            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<string>("Successfully created employee");
            return new Response<string>(HttpStatusCode.BadRequest, "Could not create employee");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<string> UpdateEmployee(Employee employee)
    {
        try
        {
            var sql = $"update employee set firstname='{employee.FirstName}',lastname='{employee.LastName}',age={employee.Age}," +
                $"position='{employee.Position}',address='{employee.Address}',email='{employee.Email}'," +
                $"companyid={employee.CompanyId},departmentid={employee.DepartmentId} where if ={employee.Id}";

            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<string>("Successfully updated employee");
            return new Response<string>(HttpStatusCode.BadRequest, "Could not update employee");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public Response<bool> DeleteEmployee(int id)
    {
        try
        {
            var sql = @$"Delete FROM employee where id={@id}";
            var result = _context.Connection().Execute(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Not found employee", false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}