using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using SupportRegister.ViewModels.Requests.Application;
using System;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public RegisterApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail(Guid id, int regisId)
        {
            try
            {
                var data = await _applicationService.GetDetailApplicationAsync(id, regisId);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            try
            {
                var data = await _applicationService.GetAllApplicationByIdAsync(id);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAllApp")]
        public async Task<IActionResult> GetAllApp()
        {
            try
            {
                var data = await _applicationService.GetAllApplicationAsync();
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RegisterApplicationCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var register = await _applicationService.RegisterApplicationAsync(request);
                if (register == 0)
                {
                    return BadRequest();
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] RegisterApplicationUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _applicationService.UpdateApplicationAsync(request);

                if (result == 0)
                {
                    return BadRequest();
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Cancel")]
        public async Task<IActionResult> Cancel([FromBody] RegisterApplicationCancelRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _applicationService.CancelApplicationAsync(request);

                if (result == 0)
                {
                    return BadRequest();
                }
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
