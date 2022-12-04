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
    public class UnacceptController : ControllerBase
    {
        private readonly ProjectSupportRegisterContext _context;
        public UnacceptController(ProjectSupportRegisterContext context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = await (from M in _context.MinusPoints
                                    join S in _context.Students on M.StudentId equals S.StudentId
                                    join U in _context.AppUsers on S.UserId equals U.Id
                                    join CL in _context.Classes on S.ClassId equals CL.ClassId
                                    join C in _context.Courses on S.IdCourse equals C.IdCourse
                                    select new UnacceptApplicationViewModel
                                    {
                                        Id = M.Id,
                                        Student = U.FullName,
                                        MSSV = U.UserName,
                                        Class = CL.NameClass,
                                        Course = C.NameCourse,
                                        Teacher = CL.Teacher,
                                        DateRegis = M.DateRegis,
                                        NameUnaccept = M.NameMinus
                                    }).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
