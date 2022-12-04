using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly ProjectSupportRegisterContext _context;
        public RegisterApplicationController(ProjectSupportRegisterContext context, IApplicationService applicationService)
        {
            _applicationService = applicationService;
            _context = context;
        }
        [HttpGet("GetAllRegis/{idUser}")]
        public async Task<IActionResult> GetAllRegis(Guid idUser)
        {
            try
            {
                var data = await _context.RegisterApplications.Include(x => x.Student)
                                                                    .ThenInclude(x => x.User)
                                                                .Include(x => x.IdStatusNavigation)
                                                                .Include(x => x.Application)
                                                                .Where(x => x.Student.User.Id == idUser)
                                                                .Select(application => new RegisterApplicationViewModel()
                                                                {
                                                                    Id = application.Id,
                                                                    Status = application.IdStatusNavigation.Name,
                                                                    Student = application.Student.User.FullName,
                                                                    NameApp = application.Application.NameApplication,
                                                                    DateRegister = application.DateRegister,
                                                                    DateReceived = application.DateReceived,
                                                                    ApplicationId = application.ApplicationId,
                                                                    StudentId = application.StudentId,
                                                                    IdStatus = application.IdStatus
                                                                }).ToListAsync();
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                var data = await _applicationService.GetApplicationAsync(id);
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
        [HttpPost("Store")]
        public async Task<IActionResult> Store(string content, string title, int id, Guid userId, int idRegis)
        {
            var RegisApp = new RegisterApplication();
            var StudentId = await (from S in _context.Students
                                   where S.UserId == userId
                                   select new
                                   {
                                       StudentId = S.StudentId
                                   }).FirstOrDefaultAsync();
            var AppId = await (from A in _context.Applications
                                   where A.IdApplication == id
                                   select new
                                   {
                                       IdApplication = A.IdApplication
                                   }).FirstOrDefaultAsync();
            var check = await _context.RegisterApplications.FindAsync(idRegis);
            if (check == null)
            {
                RegisApp.ApplicationId = AppId.IdApplication;
                RegisApp.StudentId = StudentId.StudentId;
                RegisApp.IdStatus = 4;
                RegisApp.Content = content;
                RegisApp.Dear = title;
                RegisApp.DateRegister = DateTime.Now;
                RegisApp.DateReceived = DateTime.Now.AddDays(2);
                await _context.RegisterApplications.AddAsync(RegisApp);
            }
            else
            {
                check.DateRegister = DateTime.Now;
                check.DateReceived = DateTime.Now.AddDays(2);
                check.Content = content;
                check.Dear = title;
                _context.RegisterApplications.Update(check);
            }
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPost("Submit")]
        public async Task<IActionResult> Submit(string content, string title, int id, Guid userId, int idRegis)
        {
            var StudentId = await (from S in _context.Students
                                   where S.UserId == userId
                                   select new
                                   {
                                       StudentId = S.StudentId
                                   }).FirstOrDefaultAsync();
            var AppId = await (from A in _context.Applications
                               where A.IdApplication == id
                               select new
                               {
                                   IdApplication = A.IdApplication
                               }).FirstOrDefaultAsync();
            var RegisApp = new RegisterApplication();
            var check = await _context.RegisterApplications.FindAsync(idRegis);
            if (check == null)
            {
                RegisApp.ApplicationId = AppId.IdApplication;
                RegisApp.StudentId = StudentId.StudentId;
                RegisApp.IdStatus = 1;
                RegisApp.Content = content;
                RegisApp.Dear = title;
                RegisApp.DateRegister = DateTime.Now;
                RegisApp.DateReceived = DateTime.Now.AddDays(2);
                await _context.RegisterApplications.AddAsync(RegisApp);
            } else
            {
                check.DateRegister = DateTime.Now;
                check.DateReceived = DateTime.Now.AddDays(2);
                check.IdStatus = 1;
                check.Content = content;
                check.Dear = title;
                _context.RegisterApplications.Update(check);
            }
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var appRegis = await (from R in _context.RegisterApplications
                                   where R.Id == id
                                   select new RegisterApplicationViewModel
                                   {
                                       Id = R.Id,
                                       IdStatus = R.IdStatus,
                                       ApplicationId = R.ApplicationId,
                                       StudentId = R.StudentId,
                                       DateRegister = R.DateRegister,
                                       DateReceived = R.DateReceived,
                                       Content = R.Content,
                                       Dear = R.Dear
                                   }).FirstOrDefaultAsync();
            return Ok(JsonConvert.SerializeObject(appRegis));
        }
        [HttpPost("Cancel")]
        public async Task<IActionResult> Cancel(int idRegis)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var RegisApp = await _context.RegisterApplications.FindAsync(idRegis);

                if (RegisApp == null)
                {
                    return Ok(-1);
                }
                _context.RegisterApplications.Remove(RegisApp);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Receive")]
        public async Task<IActionResult> Receive(int idRegis)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var RegisApp = await _context.RegisterApplications.FindAsync(idRegis);

                if (RegisApp == null)
                {
                    return Ok(-1);
                }
                RegisApp.IdStatus = 6;
                _context.RegisterApplications.Update(RegisApp);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
