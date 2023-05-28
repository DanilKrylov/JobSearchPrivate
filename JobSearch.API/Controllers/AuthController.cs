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
        public IActionResult Login(LoginViewModel viewModel)
        {
            return new JsonResult(_authService.Login(viewModel.Login, viewModel.Password));
        }

        [HttpPost("googleLogin")]
        public IActionResult GoogleLogin(string email)
        {
            return new JsonResult(_authService.Login(email));
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

        [HttpPost("companyGoogleReg")]
        public IActionResult CompanyGoogleRegister(CompanyGoogleRegisterViewModel company)
        {
            return new JsonResult(_authService.CompanyRegister(company.ToModel()));
        }

        [HttpPost("workerGoogleReg")]
        public IActionResult WorkerGoogleRegister(WorkerGoogleRegisterViewModel worker)
        {
            return new JsonResult(_authService.WorkerRegister(worker.ToModel()));
        }

        [Authorize]
        [HttpPost("checkSignIn")]
        public IActionResult Check()
        {
            if (_authService.IsBanned(User.Identity.Name))
                return StatusCode(401);

            return Ok();
        }
    }
}
