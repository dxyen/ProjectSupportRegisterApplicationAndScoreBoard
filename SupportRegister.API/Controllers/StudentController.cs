using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.EF;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public StudentController(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAllStudent/{userId}")]
        public async Task<IActionResult> GetAllStudent(Guid userId)
        {
            var query = await _context.Students
                .Where(x => x.UserId == userId)
                .Select(student => new StudentViewModel()
                {
                    StudentId = student.StudentId,
                    YearStart = student.YearStart,
                    YearEnd = student.YearEnd
                }).FirstOrDefaultAsync();
            return Ok(query);
        }
    }
}
