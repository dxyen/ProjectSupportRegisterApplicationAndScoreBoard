using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EmailController : ControllerBase
    {
        private readonly ProjectSupportRegisterContext _context;
        public EmailController(ProjectSupportRegisterContext context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await _context.EmailAdmins
                    .Select(email => new EmailAdminViewModel()
                    {
                        Id = email.Id,
                        EmailAdmin1 = email.EmailAdmin1,
                        Name = email.Name,
                        Password = email.Password,
                    }).ToListAsync();
                return Ok(query);
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
                var query = await _context.EmailAdmins
                    .Where(x => x.Id == id)
                    .Select(email => new EmailAdminViewModel()
                    {
                        Id = email.Id,
                        EmailAdmin1 = email.EmailAdmin1,
                        Name = email.Name,
                        Password = email.Password,
                    }).FirstOrDefaultAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(int id, string name, string email, string password)
        {
            var mail = await _context.EmailAdmins.FindAsync(id);
            if (mail == null)
            {
                return Ok(-1);
            }
            mail.Name = name;
            mail.EmailAdmin1 = email;
            mail.Password = password;
            _context.EmailAdmins.Update(mail);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}
