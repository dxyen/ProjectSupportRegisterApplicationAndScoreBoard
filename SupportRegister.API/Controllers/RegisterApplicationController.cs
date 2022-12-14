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
        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll(Guid id)
        //{
        //    try
        //    {
        //        var data = await _applicationService.GetAllApplicationByIdAsync(id);
        //        return Ok(JsonConvert.SerializeObject(data));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
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
        public async Task<IActionResult> Store(string content, string title, int id, Guid userId)
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
            var check = await _context.RegisterApplications.FindAsync(AppId.IdApplication, StudentId.StudentId);
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
        public async Task<IActionResult> Submit(string content, string title, int id, Guid userId)
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
            var check = await _context.RegisterApplications.FindAsync(AppId.IdApplication, StudentId.StudentId);
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
        [HttpGet("Update")]
        public async Task<IActionResult> Update(int idApp, Guid userId, int idStatus)
        {
            var StudentId = await (from S in _context.Students
                                   where S.UserId == userId
                                   select new
                                   {
                                       StudentId = S.StudentId
                                   }).FirstOrDefaultAsync();
            var appRegis = await (from R in _context.RegisterApplications
                                   where R.IdStatus == idStatus && R.ApplicationId == idApp && R.StudentId == StudentId.StudentId
                                   select new
                                   {
                                       IdStatus = R.IdStatus,
                                       IdApplication = R.ApplicationId,
                                       StudentId = R.StudentId,
                                       DateRegister = R.DateRegister,
                                       DateReceived = R.DateReceived,
                                       Content = R.Content,
                                       Title = R.Dear
                                   }).FirstOrDefaultAsync();
            var RegisApp = new RegisterApplicationViewModel();
            RegisApp.Content = appRegis.Content;
            RegisApp.IdStatus = appRegis.IdStatus;
            RegisApp.ApplicationId = appRegis.IdApplication;
            RegisApp.DateRegister = appRegis.DateRegister;
            RegisApp.DateReceived = appRegis.DateReceived;
            RegisApp.Dear = appRegis.Title;
            RegisApp.StudentId = appRegis.StudentId;
            return Ok(JsonConvert.SerializeObject(RegisApp));
        }
        [HttpPost("Cancel")]
        public async Task<IActionResult> Cancel(int cancelId, Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var StudentId = await (from S in _context.Students
                                       where S.UserId == userId
                                       select new
                                       {
                                           StudentId = S.StudentId
                                       }).FirstOrDefaultAsync();
                var RegisApp = await _context.RegisterApplications.FindAsync(cancelId, StudentId.StudentId);

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
    }
}
