using JobSearch.API.ViewModels;
using JobSearch.Logic.Interfaces;
using JobSearch.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            return new JsonResult(_authService.Login(login, password));
        }

        [HttpPost("workerReg")]
        public IActionResult WorkerRegister(WorkerRegisterViewModel worker)
        {
            return new JsonResult(_authService.WorkerRegister(worker.ToModel()));
        }

        [HttpPost("companyReg")]
        public IActionResult CompanyRegister(CompanyRegisterViewModel company)
        {
            return new JsonResult(_authService.CompanyRegister(company.ToModel()));
        }

        [Authorize]
        [HttpPost("checkSignIn")]
        public IActionResult Check()
        {
            return Ok();
        }
    }
}
