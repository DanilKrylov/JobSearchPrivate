using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/companyAction")]
    [Authorize(Roles = "Company")]
    public class CompanyActionsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IFeadbackRepository _feadbackRepository;

        public CompanyActionsController(IJobRepository jobRepository, IUserRepository userRepository, ISkillRepository skillRepository, IFeadbackRepository feadbackRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _feadbackRepository = feadbackRepository;
        }

        [HttpPost("addJob")]
        public IActionResult AddJob(string jobName, string description, int mainSkillId)
        {
            var company = (Company)_userRepository.GetUser(User.Identity.Name);
            var skill = _skillRepository.GetSkill(mainSkillId);
            var job = new Job
            {
                MainSkill = skill,
                Description = description,
                Company = company,
                JobName = jobName,
            };
            _jobRepository.AddJob(job);

            return Ok();
        }

        [HttpPost("removeJob")]
        public IActionResult RemoveJob(int jobId)
        {
            _jobRepository.RemoveJob(jobId);
            return Ok();
        }

        [HttpPost("getJobs")]
        public IActionResult GetCompanyJobs()
        {
            return new JsonResult(_jobRepository.GetCompanyJobs(User.Identity.Name));
        }

        [HttpPost("setFeadbackResult")]
        public IActionResult SetFeadbackResult(int feadbackId, bool isAccepted)
        {
            var feadback = _feadbackRepository.GetFeadback(feadbackId);
            feadback.Аccepted = isAccepted;
            _feadbackRepository.UpdateFeadback(feadback);
            return Ok();
        }
    }
}
