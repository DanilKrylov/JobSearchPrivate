using JobSearch.Repositories.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagsController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        public TagsController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return new JsonResult(_skillRepository.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add(string tagName)
        {
            var skill = new Tag() { TagName = tagName };
            _skillRepository.AddSkill(skill);
            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult Remove(int skillId)
        {
            _skillRepository.DeleteSkill(skillId);
            return Ok();
        }
    }
}
