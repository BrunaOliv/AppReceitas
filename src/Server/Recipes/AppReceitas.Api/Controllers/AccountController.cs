using AppReceitas.Api.Models;
using AppReceitas.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace AppReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);
            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authenticate.RegisterUser(model.Email, model.Password);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Ok();
        }
    }
}
