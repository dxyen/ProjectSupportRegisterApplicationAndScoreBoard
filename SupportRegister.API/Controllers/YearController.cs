using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearController : ControllerBase
    {
        private readonly IYearService _yearService;
        public YearController(IYearService yearService)
        {
            _yearService = yearService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _yearService.GetAllYearAsync();
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                var data = await _yearService.GetDetailYearAsync(id);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
