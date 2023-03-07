using JobSearch.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("/api/test")]
    public class TestController : Controller
    {
        private readonly IUserRepository _userRepository;

        public TestController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("/getUsers")]
        public IActionResult GetUsers()
        {
            return new JsonResult(_userRepository.GetAdmins());
        }
    }
}
