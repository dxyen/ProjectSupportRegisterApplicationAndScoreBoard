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
using SupportRegister.Data.Models;

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
            var Student = await (from U in _context.AppUsers
                                   join S in _context.Students on U.Id equals S.UserId
                                   join C in _context.Classes on S.ClassId equals C.ClassId
                                   where U.Id == userId
                                   select new
                                   {
                                       FullName = U.FullName,
                                       MSSV = U.UserName,
                                       Class = C.NameClass,
                                       StudentId = S.StudentId
                                   }).FirstOrDefaultAsync();
            MailRequest request = new MailRequest();
            request.ToEmail = "doxuanyen2000@gmail.com";
            request.Subject = title_mail;
            request.Body = $"<h3>Được gửi từ: {Student.FullName}, MSSV: {Student.MSSV}, Lớp: {Student.Class} </h3>";
            request.Body += $"<p>{content_mail}</p>";
            await _mailService.SendEmailAsync(request);
            Feedback feedback = new Feedback();
            feedback.ContentFeedback = content_mail;
            feedback.TitleFeedback = title_mail;
            feedback.StudentId = Student.StudentId;
            await _context.Feedbacks.AddAsync(feedback);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
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
