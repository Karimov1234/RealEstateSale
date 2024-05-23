using Application.Abstractions;
using Application.Abstractions.IServices;
using Application.DTOs.UserDtos;
using Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync(CreateUserDTO student)
        {
            var data = await _userService.AddAsync(student);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync(UpdateUserDTO student)
        {
            var data = await _userService.UpdateAsync(student);
            return StatusCode(data.StatusCode, data);
        }
        [HttpDelete("{idOrName}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public async Task<IActionResult> DeleteAsync(string idOrName)
        {
            var data = await _userService.DeleteAsync(idOrName);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("{usernameorid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public async Task<IActionResult> GetRolesToUserAsync(string usernameorid)
        {
            var data = await _userService.GetRolesToUserAsync(usernameorid);
            return StatusCode(data.StatusCode, data);

        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _userService.GetAllUserAsync();
            return StatusCode(data.StatusCode, data);
        }
        [HttpPost("[action]/{userId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
        public async Task<IActionResult> AssignRolesToUserAsync(string userid, string[] roles) => await _userService.AssignRolesToUserAsync(userid, roles) is GenericResponseModel<bool> data ? StatusCode(data.StatusCode, data) : NotFound();

    }
}
