using JobSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        [HttpGet("get")]
        public IActionResult GetAll()
        {
            return new JsonResult(_companyRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_companyRepository.Get(id));
        }
    }
}
