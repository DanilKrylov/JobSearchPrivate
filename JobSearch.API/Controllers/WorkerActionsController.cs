using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IFileInfoRepository _fileInfoRepository;

        public WorkerActionsController(IUserRepository userRepository, IFeadbackRepository feadbackRepository, IJobRepository jobRepository, IFavoriteRepository favoriteRepository, IFileInfoRepository fileInfoRepository)
        {
            _userRepository = userRepository;
            _feadBackRepository = feadbackRepository;
            _jobRepository = jobRepository;
            _favoriteRepository = favoriteRepository;
            _fileInfoRepository = fileInfoRepository;
        }

        [HttpPost("giveFeadback")]
        public IActionResult GiveFeadback(int jobId, string workerComment)
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
        public IActionResult RemoveFeadback(int feadbackId)
        {
            _feadBackRepository.RemoveFeadback(feadbackId); 
            return Ok();
        }

        [HttpPost("getWorkerFeadbacks")]
        public IActionResult GetUserFeadbacks()
        {
            return new JsonResult(_feadBackRepository.GetUserFeadbacks(User.Identity.Name));
        }

        [HttpPost("addToFavorite")]
        public IActionResult AddToFavorite(int jobId)
        {
            _favoriteRepository.Add(User.Identity.Name, jobId);
            return Ok();
        }

        [HttpPost("removeFromFavorite")]
        public IActionResult RemoveFromFavorite(int jobId)
        {
            _favoriteRepository.Remove(User.Identity.Name, jobId);
            return Ok();
        }

        [HttpPost("getFavoriteJobs")]
        public IActionResult GetFavorites()
        {
            return Ok(_favoriteRepository.GetFavorites(User.Identity.Name));
        }

        [HttpPost("setCV")]
        public IActionResult SetCV(IFormFile formFile)
        {
            var login = User.Identity.Name;
            _fileInfoRepository.SetCV(formFile, login);
            return Ok();
        }

        [HttpPost("setAvatar")]
        public IActionResult SetAvatar(IFormFile formFile)
        {
            var login = User.Identity.Name;
            _fileInfoRepository.SetAvatar(formFile, login);
            return Ok();
        }
    }
}
