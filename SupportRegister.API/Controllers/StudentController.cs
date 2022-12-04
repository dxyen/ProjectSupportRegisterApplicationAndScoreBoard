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
        [HttpGet("GetStudentApp/{userId}")]
        public async Task<IActionResult> GetStudentApp(Guid userId)
        {
            var query = await _context.Students
                .Include(x => x.Class)
                .Include(x => x.IdCourseNavigation)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .Select(student => new StudentAppViewModel()
                {
                    ClassName = student.Class.NameClass,
                    Course = student.IdCourseNavigation.NameCourse,
                    FullName = student.User.FullName,
                    Address = student.User.Address,
                    Birthday = student.User.Birthday,
                    PhoneNumber = student.User.PhoneNumber,
                    Email = student.User.Email,
                    UserName = student.User.UserName,
                    YearStart = student.YearStart,
                    YearEnd= student.YearEnd,
                    Teacher = student.Class.Teacher
                }).FirstOrDefaultAsync();
            return Ok(query);
        }
        [HttpGet("GetListClass")]
        public async Task<IActionResult> GetListClass()
        {
            var query = await _context.Classes
                .Select(classes => new ClassViewModel()
                {
                    ClassId = classes.ClassId,
                    NameClass = classes.NameClass,
                    Teacher = classes.Teacher
                }).ToListAsync();
            return Ok(query);
        }
        [HttpGet("GetListCourse")]
        public async Task<IActionResult> GetListCourse()
        {
            var query = await _context.Courses
                .Select(Course => new CourseViewModel()
                {
                    IdCourse = Course.IdCourse,
                    NameCourse = Course.NameCourse
                }).ToListAsync();
            return Ok(query);
        }
    }
}
