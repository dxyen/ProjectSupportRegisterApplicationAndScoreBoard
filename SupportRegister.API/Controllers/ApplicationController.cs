using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.EF;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ProjectSupportRegisterContext _context;
        public ApplicationController(ProjectSupportRegisterContext context)
        {
            _context = context;
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
                        ApplicationId = app.ApplicationId,
                        StudentId = app.Student.StudentId,
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
        public async Task<IActionResult> Update(int id, int idStudent, int idStatus)
        {
            var Regis = await _context.RegisterApplications.FindAsync(id, idStudent);

            if (Regis == null)
            {
                return Ok(-1);
            }
            Regis.IdStatus = idStatus;
            _context.RegisterApplications.Update(Regis);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int appId, int studentId)
        {
            var Regis = await _context.RegisterApplications.FindAsync(appId, studentId);

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
