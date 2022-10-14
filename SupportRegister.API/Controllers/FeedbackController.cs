using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using SupportRegister.ViewModels.Requests.Feedback;
using System;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _feedbackService.GetAllFeedbackAsync();
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAllByUser")]
        public async Task<IActionResult> GetDetail(Guid id)
        {
            try
            {
                var data = await _feedbackService.GetAllFeedbackByIdAsync(id);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] FeedbackUpdateRequest request)
        {
            try
            {
                await _feedbackService.UpdateFeedbackAsync(request);
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] FeedbackCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var register = await _feedbackService.CreateFeedbackAsync(request);
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
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(FeedbackDeleteRequest request)
        {
            try
            {
                await _feedbackService.DeleteFeedbackAsync(request);
                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
