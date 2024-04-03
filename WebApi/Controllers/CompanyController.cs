using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Responses;
using WebApi.Services;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("api/Company/")]
    public class CompanyController(ICompanyService companyService): ControllerBase
    {
        private readonly ICompanyService _companyService=companyService;
        [HttpGet]
        public Response<List<Company>> GetCompany()
        {
            return _companyService.GetAllCompanies();
        }

        [HttpGet("{companyId:int}")]
        public Response<Company> GetCompanyById(int companyId)
        {
            return _companyService.GetCompanyById(companyId);
        }
 
        [HttpPost]
        public Response<string> Add(Company company)
        {
            return _companyService.AddCompany(company);
        }
        [HttpPut]
        public Response<string> Update(Company company)
        {
            return _companyService.UpdateCompany(company);
        }
        [HttpDelete("{companyId:int}")]
        public Response<bool> Delete(int companyId)
        {
            return _companyService.DeleteCompany(companyId);
        }

    }
}
