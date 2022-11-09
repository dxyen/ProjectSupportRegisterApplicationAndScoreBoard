using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.ViewModels.Requests.Mail;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ProjectSupportRegisterContext _context;
        private readonly IMailService _mailService;
        public ApplicationController(IMailService mailService, ProjectSupportRegisterContext context)
        {
            _context = context;
            _mailService = mailService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await _context.RegisterApplications
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.IdStatusNavigation)
                    .Include(x => x.Application)
                    .Select(app => new RegisterApplicationViewModel()
                    {
                        ApplicationId = app.ApplicationId,
                        NameApp = app.Application.NameApplication,
                        Student = app.Student.User.FullName,
                        Status = app.IdStatusNavigation.Name,
                        DateReceived = app.DateReceived,
                        DateRegister = app.DateRegister,
                        IdStatus = app.IdStatus,
                        UserName = app.Student.User.UserName,
                        StudentId = app.Student.StudentId
                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAllAppUnconfirm")]
        public async Task<IActionResult> GetAllAppUnconfirm()
        {
            try
            {
                var query = await _context.RegisterApplications
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.IdStatusNavigation)
                    .Include(x => x.Application)
                    .Where(x => x.IdStatus == 1)
                    .Select(app => new RegisterApplicationViewModel()
                    {
                        ApplicationId = app.ApplicationId,
                        NameApp = app.Application.NameApplication,
                        Student = app.Student.User.FullName,
                        Status = app.IdStatusNavigation.Name,
                        DateReceived = app.DateReceived,
                        DateRegister = app.DateRegister,
                        IdStatus = app.IdStatus,
                        UserName = app.Student.User.UserName,
                        StudentId = app.Student.StudentId
                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CountAppUnconfirm")]
        public async Task<IActionResult> CountAppUnconfirm()
        {
            try
            {
                var query = await (from r in _context.RegisterApplications
                                   where r.IdStatus == 1
                                   select r).CountAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAllAppUnprint")]
        public async Task<IActionResult> GetAllAppUnprint()
        {
            try
            {
                var query = await _context.RegisterApplications
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.IdStatusNavigation)
                    .Include(x => x.Application)
                    .Where(x => x.IdStatus == 3)
                    .Select(app => new RegisterApplicationViewModel()
                    {
                        ApplicationId = app.ApplicationId,
                        NameApp = app.Application.NameApplication,
                        Student = app.Student.User.FullName,
                        Status = app.IdStatusNavigation.Name,
                        DateReceived = app.DateReceived,
                        DateRegister = app.DateRegister,
                        IdStatus = app.IdStatus,
                        UserName = app.Student.User.UserName,
                        StudentId = app.Student.StudentId
                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CountAppUnprint")]
        public async Task<IActionResult> CountAppUnprint()
        {
            try
            {
                var query = await (from r in _context.RegisterApplications
                                   where r.IdStatus == 3
                                   select r).CountAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail(int appId, int studentId)
        {
            try
            {
                var query = await _context.RegisterApplications
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.IdStatusNavigation)
                    .Include(x => x.Application)
                    .Where(x => x.Student.StudentId == studentId)
                    .Where(x => x.ApplicationId == appId)
                    .Select(app => new RegisterApplicationViewModel()
                    {
                        Id = app.Id,
                        ApplicationId = app.ApplicationId,
                        StudentId = app.Student.StudentId,
                        UserId = app.Student.UserId,
                        NameApp = app.Application.NameApplication,
                        Student = app.Student.User.FullName,
                        Status = app.IdStatusNavigation.Name,
                        DateReceived = app.DateReceived,
                        DateRegister = app.DateRegister,
                        IdStatus = app.IdStatus,
                        UserName = app.Student.User.UserName,
                        Content = app.Content,
                        Dear =app.Dear
                    }).FirstOrDefaultAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id, int idStatus)
        {
            var Regis = await _context.RegisterApplications.FindAsync(id);

            if (Regis == null)
            {
                return Ok(-1);
            } else
            {
                var Student = await (from U in _context.AppUsers
                                     join S in _context.Students on U.Id equals S.UserId
                                     join D in _context.DetailRegisterScoreboards on S.StudentId equals D.StudentId
                                     join R in _context.RegisterScoreboards on D.RegisId equals R.IdRegisterScoreboard
                                     join C in _context.Classes on S.ClassId equals C.ClassId
                                     where S.StudentId == Regis.StudentId
                                     select new
                                     {
                                         Email = U.Email,
                                         FullName = U.FullName,
                                         MSSV = U.UserName,
                                         Class = C.NameClass,
                                         StudentId = S.StudentId,
                                         DateRegister = R.DateRegister,
                                         DateReceived = R.DateReceived ?? DateTime.Now
                                     }).FirstOrDefaultAsync();
                MailRequest request = new MailRequest();
                if (idStatus == 5)
                {
                    request.ToEmail = Student.Email;
                    request.Subject = "Đăng ký đơn";
                    request.Body = $"<h3>Sinh viên đăng ký: {Student.FullName} </h3>";
                    request.Body += $"<p>Đăng ký vào ngày {Student.DateRegister}</p>";
                    request.Body += $"<p>Trạng thái: Đã được in</p>";
                    request.Body += $"<p>Sinh viên đã có thể đến khoa để nhận đơn</p>";
                    await _mailService.SendEmailAdminAsync(request);
                }
                else
                {
                    request.ToEmail = Student.Email;
                    request.Subject = "Đăng ký đơn";
                    request.Body = $"<h3>Sinh viên đăng ký: {Student.FullName} </h3>";
                    request.Body += $"<p>Đăng ký vào ngày {Student.DateRegister}</p>";
                    request.Body += $"<p>Trạng thái: Đã được xác nhận yêu cầu</p>";
                    request.Body += $"<p>Sinh viên có thể đến khoa để nhận đơn vào ngày {Student.DateReceived.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}</p>";
                    await _mailService.SendEmailAdminAsync(request);
                }
                Regis.IdStatus = idStatus;
                _context.RegisterApplications.Update(Regis);
                var result = await _context.SaveChangesAsync();
                return Ok(result);
            }
            
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var Regis = await _context.RegisterApplications.FindAsync(id);

            if (Regis == null)
            {
                return Ok(-1);
            }
            _context.RegisterApplications.Remove(Regis);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}
