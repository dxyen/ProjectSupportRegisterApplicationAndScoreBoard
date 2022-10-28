using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.Models;

namespace SupportRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterScoreboardController : ControllerBase
    {
        private readonly IScoreboardService _scoreboardService;
        private readonly IYearService _yearService;
        private readonly ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;
        public RegisterScoreboardController(ProjectSupportRegisterContext context, IMapper mapper, IScoreboardService scoreboardService, IYearService yearService)
        {
            _scoreboardService = scoreboardService;
            _yearService = yearService;
            _context = context;
            _mapper = mapper;
        }
        //[HttpGet("GetYear")]
        //public async Task<IActionResult> GetYear()
        //{
        //}
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail(Guid id, int regisId)
        {
            try
            {
                var data = await _scoreboardService.GetDetailScoreboardByIdAsync(id, regisId);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetAll/{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            try
            {
                var data = await _scoreboardService.GetAllScoreboardByIdAsync(id);
                return Ok(JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(string option, int yearstart_stu, int yearend_stu, int id_start, int id_end, int soluong, Guid userId)
        {
            var RegisScore = new RegisterScoreboard();
            var DetailRegisScore = new DetailRegisterScoreboard();
            RegisScore.DateRegister = DateTime.Now;
            RegisScore.DateReceived = DateTime.Now.AddDays(2);
            RegisScore.IdStatus = 1;
            var id = (from R in _context.RegisterScoreboards
                      select R.IdRegisterScoreboard).Max() + 1;
            RegisScore.IdRegisterScoreboard = id;
            await _context.RegisterScoreboards.AddAsync(RegisScore);
            DetailRegisScore.RegisId = id;
            DetailRegisScore.YearSemesterIdStart = id_start;
            DetailRegisScore.YearSemesterIdEnd = id_end;
            var StudentId = await (from S in _context.Students
                                   where S.UserId == userId
                                   select new
                                   {
                                       StudentId = S.StudentId
                                   }).FirstOrDefaultAsync();
            DetailRegisScore.StudentId = StudentId.StudentId;
            DetailRegisScore.Amount = soluong;
            if (option == "some")
            {
                var YearSemesterStart = await (from YS in _context.YearSemesters
                                               join Y in _context.Years on YS.IdYear equals Y.IdYear
                                               join S in _context.Semesters on YS.IdSemester equals S.IdSemester
                                               where YS.Id == id_start
                                               select new
                                               {
                                                   YearStart = Y.Year1,
                                                   SemesterStart = S.NameSemester
                                               }).FirstOrDefaultAsync();
                var YearSemesterEnd = await (from YS in _context.YearSemesters
                                             join Y in _context.Years on YS.IdYear equals Y.IdYear
                                             join S in _context.Semesters on YS.IdSemester equals S.IdSemester
                                             where YS.Id == id_end
                                             select new
                                             {
                                                 YearEnd = Y.Year1,
                                                 SemesterEnd = S.NameSemester
                                             }).FirstOrDefaultAsync();
                int YearStart = yearstart_stu <= YearSemesterStart.YearStart ? YearSemesterStart.YearStart : yearstart_stu;
                int YearEnd = yearend_stu >= YearSemesterEnd.YearEnd ? YearSemesterEnd.YearEnd : yearend_stu;
                int Price = (((YearEnd - YearStart) + 1) * 2000) * soluong;
                DetailRegisScore.YearStart = YearStart;
                DetailRegisScore.YearEnd = YearEnd;
                DetailRegisScore.SemesterStart = YearSemesterStart.SemesterStart;
                DetailRegisScore.SemesterEnd = YearSemesterEnd.SemesterEnd;
                DetailRegisScore.Price = Price;
            }
            else
            {
                int Price = (((yearend_stu - yearstart_stu) + 1) * 2000) * soluong;
                DetailRegisScore.YearStart = yearstart_stu;
                DetailRegisScore.YearEnd = yearend_stu;
                DetailRegisScore.SemesterStart = null;
                DetailRegisScore.SemesterEnd = null;
                DetailRegisScore.Price = Price;
            }
            await _context.DetailRegisterScoreboards.AddAsync(DetailRegisScore);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPost("Cancel")]
        public async Task<IActionResult> Cancel(int cancelId)
        {
            var RegisScore = await _context.RegisterScoreboards.FindAsync(cancelId);

            if (RegisScore == null)
            {
                return Ok(-1);
            }
            RegisScore.IdStatus = 2;
            _context.RegisterScoreboards.Update(RegisScore);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}
