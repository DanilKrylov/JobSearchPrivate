using JobSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/adminActions")]
    [Authorize(Roles ="Admin")]
    public class AdminActionsController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AdminActionsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("ban")]
        public IActionResult BanUser(string email)
        {
            _userRepository.BanCompanyOrWorker(email);

            return Ok();
        }

        [HttpPost("unban")]
        public IActionResult UnbanUser(string email)
        {
            _userRepository.UnbanCompanyOrWorker(email);
            return Ok();
        }
    }
}
