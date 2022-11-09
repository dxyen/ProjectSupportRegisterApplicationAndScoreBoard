﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ScoreboardController : ControllerBase
    {
        private readonly ProjectSupportRegisterContext _context;
        private readonly IMailService _mailService;
        public ScoreboardController(IMailService mailService, ProjectSupportRegisterContext context)
        {
            _mailService = mailService;
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await _context.DetailRegisterScoreboards
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.Regis)
                        .ThenInclude(x => x.IdStatusNavigation)
                    .Select(score => new RegisterScoreboardViewModel()
                    {
                        IdRegis = score.RegisId,
                        Student = score.Student.User.FullName,
                        Status = score.Regis.IdStatusNavigation.Name,
                        DateReceived = score.Regis.DateRegister,
                        DateRegister = score.Regis.DateRegister,
                        Amount = score.Amount,
                        UserName = score.Student.User.UserName
                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAllScoreUnconfirm")]
        public async Task<IActionResult> GetAllUnconfirm()
        {
            try
            {
                var query = await _context.DetailRegisterScoreboards
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.Regis)
                        .ThenInclude(x => x.IdStatusNavigation)
                    .Where(x => x.Regis.IdStatus == 1)
                    .Select(score => new RegisterScoreboardViewModel()
                    {
                        IdRegis = score.RegisId,
                        Student = score.Student.User.FullName,
                        Status = score.Regis.IdStatusNavigation.Name,
                        DateReceived = score.Regis.DateRegister,
                        DateRegister = score.Regis.DateRegister,
                        Amount = score.Amount,
                        UserName = score.Student.User.UserName
                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CountScoreUnconfirm")]
        public async Task<IActionResult> CountUnconfirm()
        {
            try
            {
                var query = await (from r in _context.RegisterScoreboards
                                   where r.IdStatus == 1
                                   select r).CountAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAllScoreUnprint")]
        public async Task<IActionResult> GetAllScoreUnprint()
        {
            try
            {
                var query = await _context.DetailRegisterScoreboards
                    .Include(x => x.Student)
                       .ThenInclude(x => x.User)
                    .Include(x => x.Regis)
                        .ThenInclude(x => x.IdStatusNavigation)
                    .Where(x => x.Regis.IdStatus == 3)
                    .Select(score => new RegisterScoreboardViewModel()
                    {
                        IdRegis = score.RegisId,
                        Student = score.Student.User.FullName,
                        Status = score.Regis.IdStatusNavigation.Name,
                        DateReceived = score.Regis.DateRegister,
                        DateRegister = score.Regis.DateRegister,
                        Amount = score.Amount,
                        UserName = score.Student.User.UserName
                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CountScoreUnprint")]
        public async Task<IActionResult> CountScoreUnprint()
        {
            try
            {
                var query = await (from r in _context.RegisterScoreboards
                                   where r.IdStatus == 3
                                   select r).CountAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetDetail/{scoreId}")]
        public async Task<IActionResult> GetDetail(int scoreId)
        {
            try
            {
                var query = await _context.DetailRegisterScoreboards
                     .Include(x => x.Student)
                        .ThenInclude(x => x.User)
                     .Include(x => x.Regis)
                         .ThenInclude(x => x.IdStatusNavigation)
                    .Where(x => x.RegisId == scoreId)
                    .Select(score => new RegisterScoreboardViewModel()
                     {
                         IdRegis = score.RegisId,
                         idStudent = score.Student.StudentId,
                         Student = score.Student.User.FullName,
                         Status = score.Regis.IdStatusNavigation.Name,
                         DateReceived = score.Regis.DateRegister,
                         DateRegister = score.Regis.DateRegister,
                         Amount = score.Amount,
                         UserName = score.Student.User.UserName,
                         PriceTotal = score.Price,
                         YearSemesterStart = score.YearSemesterIdStartNavigation.YearSemester1,
                         YearSemesterEnd = score.YearSemesterIdEndNavigation.YearSemester1
                    }).FirstOrDefaultAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id, int idStatus, int idStudent)
        {
            var Student = await (from U in _context.AppUsers
                                 join S in _context.Students on U.Id equals S.UserId
                                 join D in _context.DetailRegisterScoreboards on S.StudentId equals D.StudentId
                                 join R in _context.RegisterScoreboards on D.RegisId equals R.IdRegisterScoreboard
                                 join C in _context.Classes on S.ClassId equals C.ClassId
                                 where S.StudentId == idStudent
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
                request.Subject = "Đăng ký in bảng điểm";
                request.Body = $"<h3>Sinh viên đăng ký: {Student.FullName} </h3>";
                request.Body += $"<p>Đăng ký vào ngày {Student.DateRegister}</p>";
                request.Body += $"<p>Trạng thái: Đã được in</p>";
                request.Body += $"<p>Sinh viên đã có thể đến khoa để nhận đơn</p>";
                await _mailService.SendEmailAdminAsync(request);
            }
            else
            {
                request.ToEmail = Student.Email;
                request.Subject = "Đăng ký in bảng điểm";
                request.Body = $"<h3>Sinh viên đăng ký: {Student.FullName} </h3>";
                request.Body += $"<p>Đăng ký vào ngày {Student.DateRegister}</p>";
                request.Body += $"<p>Trạng thái: Đã được xác nhận yêu cầu</p>";
                request.Body += $"<p>Sinh viên có thể đến khoa để nhận đơn vào ngày {Student.DateReceived.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}</p>";
                await _mailService.SendEmailAdminAsync(request);
            }
            var RegisScore = await _context.RegisterScoreboards.FindAsync(id);

            if (RegisScore == null)
            {
                return Ok(-1);
            }
            RegisScore.IdStatus = idStatus;
            _context.RegisterScoreboards.Update(RegisScore);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var RegisScore = await _context.RegisterScoreboards.FindAsync(id);

            if (RegisScore == null)
            {
                return Ok(-1);
            }
            _context.RegisterScoreboards.Remove(RegisScore);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}