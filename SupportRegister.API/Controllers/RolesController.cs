using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportRegister.Application.System.Roles;
using SupportRegister.ViewModels.Requests.System.Roles;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.CreateAsync(request);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.ToList()[0].Description);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] RoleUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _roleService.UpdateAsync(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _roleService.GetByIdAsync(id);
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
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _roleService.GetAllRolesAsync();
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
            var result = await _roleService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
