using Application.Abstractions.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance.Implementations.Services;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authoService;

        public AuthController(IAuthService authoService)
        {
            _authoService = authoService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string usernameOrEmail, string password)
        {
            var data = await _authoService.LoginAsync(usernameOrEmail, password);
            return StatusCode(data.StatusCode, data);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> LogOut(string usernameOremail)
        {
            var data = await _authoService.LogOutAsync(usernameOremail);
            return StatusCode(data.StatusCode, data);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(string email, string curPas, string newPas)
        {
            var data = await _authoService.PasswordResetAsync(email, curPas, newPas);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateNewRefreshToken(string refreshtoken)
        {
            var data = await _authoService.CreateNewResreshTokenAsync(refreshtoken);
            return StatusCode(data.StatusCode, data);

        }
    }
}
