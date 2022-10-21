using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.ViewModels.Requests.Feedback;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SupportRegister.ViewModels.Requests.Mail;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMailService _mailService;
        private readonly ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;
        public FeedbackController(IMailService mailService, ProjectSupportRegisterContext context, IMapper mapper, IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
            _context = context;
            _mailService = mailService;
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
        public async Task<IActionResult> Create(string title_mail, string content_mail, Guid userId)
        {
            var StudentId = await (from S in _context.Students
                                   where S.UserId == userId
                                   select new
                                   {
                                       StudentId = S.StudentId
                                   }).FirstOrDefaultAsync();
            MailRequest request = new MailRequest();
            request.ToEmail = "doxuanyen2000@gmail.com";
            request.Subject = "Tài khoản HYPE shop";
            request.Body = "<h1>Chào <span style=\"color: red\">" + "Đỗ Xuân Yên" + "</span></h1>";
            request.Body += "<h5>Tài khoản của bạn là:</h5>";
            request.Body += " <div><span> Tài khoản: </span><span>" + "doxuanyen2000@gmail.com" + "</span>" + "<br />"
                        + "<span> Mật khẩu: </span><span>" + "doxuanyen2000@gmail.com" + "</span></div>";
            await _mailService.SendEmailAsync(request);
            return Ok(true);
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
