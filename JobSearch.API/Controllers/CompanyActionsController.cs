using JobSearch.API.ViewModels;
using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/companyAction")]
    [Authorize(Roles="Company")]
    public class CompanyActionsController : Controller
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IFeadbackRepository _feadbackRepository;
        private readonly ICompanyRepository _companyRepository;

        public CompanyActionsController(IJobRepository jobRepository, IUserRepository userRepository, ISkillRepository skillRepository, IFeadbackRepository feadbackRepository, ICompanyRepository companyRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _skillRepository = skillRepository;
            _feadbackRepository = feadbackRepository;
            _companyRepository = companyRepository;
        }

        [HttpGet("companyInfo")]
        public  IActionResult GetCompanyInfo()
        {
            return new JsonResult(_companyRepository.Get(User.Identity.Name));
        }

        [HttpPost("addJob")]
        public IActionResult AddJob(JobAddViewModel viewModel)
        {
            var company = (Company)_userRepository.GetUser(User.Identity.Name);
            var tags = viewModel.TagIdes.Select(c => _skillRepository.GetSkill(c)).ToList();
            var job = new Job
            {
                Tags = tags,
                Description = viewModel.Description,
                Company = company,
                JobName = viewModel.JobName,
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

        [HttpGet("getJobs")]
        public IActionResult GetCompanyJobs()
        {
            return new JsonResult(_jobRepository.GetCompanyJobs(User.Identity.Name));
        }

        [HttpPost("setFeadbackResult")]
        public IActionResult SetFeadbackResult(int feadbackId, bool isAccepted)
        {
            var feadback = _feadbackRepository.GetFeadback(feadbackId);
            feadback.Accepted = isAccepted;
            _feadbackRepository.UpdateFeadback(feadback);
            return Ok();
        }

        [HttpPost("updateCompany")]
        public IActionResult UpdateCompany(UpdateCompanyViewModel viewModel)
        {
            _companyRepository.Update(User.Identity.Name, viewModel.CompanyName, viewModel.Description, viewModel.Address);
            return Ok();
        }
    }
}
