using Dapper;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Responses;
using System.Net;

namespace WebApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DapperContext _context;
        public CompanyService()
        {
            _context = new DapperContext();
        }
        public Response<string> AddCompany(Company company)
        {
            try
            {
                var sql = $"insert into company(name,Address,CreatedAt)" +
                    $"values('{company.Name}','{company.Address}','{company.CreatedAt}')";
                var result = _context.Connection().Execute(sql);
                if (result > 0)
                {
                    return new Response<string>("Company succesfully created");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Could not create company");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Response<bool> DeleteCompany(int id)
        {
            try
            {
                var sql = $"Delete from company where id={@id}";
                var result = _context.Connection().Execute(sql);
                if (result > 0)
                {
                    return new Response<bool>(true);
                }
                return new Response<bool>(HttpStatusCode.BadRequest, "Not found company");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Response<List<Company>> GetAllCompanies()
        {
            try
            {
                var sql = $"Select * from company";
                var result = _context.Connection().Query<Company>(sql).ToList();
                return new Response<List<Company>>(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<List<Company>>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public Response<Company> GetCompanyById(int id)
        {
            try
            {
                var sql = $"Select * from company where id={@id}";
                var result = _context.Connection().QueryFirstOrDefault(sql);
                if (result != null)
                {
                    return new Response<Company>(result);
                }
                return new Response<Company>(HttpStatusCode.BadRequest, "Company not found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return new Response<Company>(HttpStatusCode.InternalServerError,e.Message);
            }
            
        }

        public Response<string> UpdateCompany(Company company)
        {
            try
            {
                var sql = $"update company set name='{company.Name}',Address='{company.Address}',CreatedAt='{company.CreatedAt}'" +
                    $"where id={company.Id}";
                var result = _context.Connection().Execute(sql);
                if (result>0)
                {
                    return new Response<string>("Succesfully updated company");
                }
                return new Response<string>(HttpStatusCode.BadRequest, "Company not found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
            }
        }
    }
}
