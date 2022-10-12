using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using SupportRegister.ViewModels.Requests.Scoreboard;
using System;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterScoreboardController : ControllerBase
    {
        private readonly IScoreboardService _scoreboardService;
        public RegisterScoreboardController(IScoreboardService scoreboardService)
        {
            _scoreboardService = scoreboardService;
        }
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail(Guid id, int regisId)
        {
            try
            {
                var data = await _scoreboardService.GetDetailScoreboardByIdAsync(id, regisId);
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
                var data = await _scoreboardService.GetAllScoreboardByIdAsync(id);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RegisterScoreboardCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var register = await _scoreboardService.RegisterScoreboardAsync(request);
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
        public async Task<IActionResult> Update([FromBody] RegisterScoreboardUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _scoreboardService.UpdateScoreboardAsync(request);

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
        public async Task<IActionResult> Cancel([FromBody] RegisterScoreboardCancelRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _scoreboardService.CancelScoreboardAsync(request);

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
