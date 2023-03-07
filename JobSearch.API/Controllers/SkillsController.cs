using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        public SkillsController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return new JsonResult(_skillRepository.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add(string skillName)
        {
            var skill = new Skill() { SkillName = skillName };
            _skillRepository.AddSkill(skill);
            return Ok();
        }
    }
}
