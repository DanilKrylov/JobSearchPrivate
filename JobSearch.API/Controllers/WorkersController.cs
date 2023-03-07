using JobSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/workers")]
    public class WorkersRepository : Controller
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkersRepository(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            return new JsonResult(_workerRepository.GetWorkers());
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_workerRepository.GetWorker(id));
        }
    }
}
