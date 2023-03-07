using JobSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        public JobsController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            return new JsonResult(_jobRepository.GetJobs());
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_jobRepository.GetJob(id));
        }
    }
}
