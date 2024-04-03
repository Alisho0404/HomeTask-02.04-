using WebApi.Models;
using WebApi.Responses;

namespace WebApi.Services
{
    public interface ICompanyService
    {
        Response<List<Company>> GetAllCompanies(); 
        Response<Company> GetCompanyById(int id);
        Response<string> AddCompany(Company company);
        Response<string> UpdateCompany(Company company);
        Response<bool> DeleteCompany(int id);
    }
}
