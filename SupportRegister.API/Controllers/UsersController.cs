using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportRegister.Application.System.Users;
using SupportRegister.ViewModels.Requests.System.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.AuthenticateAsync(request);
            return Ok(resultToken);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.CreateAsync(request);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.ToList()[0].Description);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.UpdateAsync(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetDetails/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result.IsSuccessed)
            {
                return Ok(result.ResultObj);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            if (result.IsSuccessed)
            {
                return Ok(result.ResultObj);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost("CheckPassword")]
        public async Task<IActionResult> CheckPassword(AccountChangePassword loginUser)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var isLogin = await _userService.CheckPassword(loginUser);
            return Ok(isLogin);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(AccountChangePassword changePasswordUser)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var isChange = await _userService.ChangePassword(changePasswordUser);
            return Ok(isChange);
        }
    }
}
