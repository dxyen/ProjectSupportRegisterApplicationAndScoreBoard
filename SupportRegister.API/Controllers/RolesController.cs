using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupportRegister.Application.System.Roles;
using SupportRegister.ViewModels.Requests.System.Roles;
using SupportRegister.ViewModels.ViewModels;
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
        [Route("Create")]
        public async Task<IActionResult> Create(RoleCreateRequest request)
        {
            try
            {
                var check = await _roleService.GetAllRolesAsync();
                foreach (var item in check.ResultObj)
                {
                    if (item.Name == request.Name)
                    {
                        return BadRequest();
                    }
                }
                await _roleService.CreateAsync(request);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RoleUpdateRequest request)
        {
            var check = await _roleService.GetAllRolesAsync();
            foreach (var item in check.ResultObj)
            {
                if (item.Id == request.Id && item.Name == request.Name)
                {
                    await _roleService.UpdateAsync(request);
                }
                else if (item.Name == request.Name)
                { 
                    return BadRequest();
                }
                else
                {
                    await _roleService.UpdateAsync(request);
                }
            }
            return Ok(true);
        }
        [HttpGet]
        [Route("GetDetails/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
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
        [Route("GetList")]
        public async Task<IActionResult> GetList()
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
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _roleService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
