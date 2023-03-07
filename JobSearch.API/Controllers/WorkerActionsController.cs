using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/workerAction")]
    [Authorize(Roles ="Worker")]
    public class WorkerActionsController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IFeadbackRepository _feadBackRepository;
        private readonly IJobRepository _jobRepository;

        public WorkerActionsController(IUserRepository userRepository, IFeadbackRepository feadbackRepository, IJobRepository jobRepository)
        {
            _userRepository = userRepository;
            _feadBackRepository = feadbackRepository;
            _jobRepository = jobRepository;
        }

        [HttpPost("giveFeadback")]
        public ActionResult GiveFeadback(int jobId, string workerComment)
        {
            var worker = (Worker)_userRepository.GetUser(User.Identity.Name);
            var job = _jobRepository.GetJob(jobId);
            var feadback = new JobFeadback()
            {
                Worker = worker,
                Job = job,
                WorkerComment = workerComment,
            };

            _feadBackRepository.AddFeadback(feadback);

            return Ok();
        }

        [HttpPost("removeFeadback")]
        public ActionResult RemoveFeadback(int feadbackId)
        {
            _feadBackRepository.RemoveFeadback(feadbackId); 
            return Ok();
        }

        [HttpPost("getWorkerFeadbacks")]
        public ActionResult GetUserFeadbacks()
        {
            return new JsonResult(_feadBackRepository.GetUserFeadbacks(User.Identity.Name));
        }
    }
}
