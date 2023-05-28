using JobSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/workers")]
    public class WorkersController : Controller
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IFileInfoRepository _fileInfoRepository;

        public WorkersController(IWorkerRepository workerRepository, IFileInfoRepository fileInfoRepository)
        {
            _workerRepository = workerRepository;
            _fileInfoRepository = fileInfoRepository;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            return new JsonResult(_workerRepository.GetWorkers());
        }

        [HttpGet("get/{email}")]
        public IActionResult Get(string email)
        {
            return new JsonResult(_workerRepository.GetWorker(email));
        }

        [HttpGet("getCV/{workerEmail}")]
        public IActionResult GetCV(string workerEmail)
        {
            return Ok(_fileInfoRepository.GetCV(workerEmail));
        }
    }
}
