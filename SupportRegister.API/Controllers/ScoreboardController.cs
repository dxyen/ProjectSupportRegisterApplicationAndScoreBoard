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
    public class ScoreboardController : ControllerBase
    {
        private readonly ProjectSupportRegisterContext _context;
        public ScoreboardController(ProjectSupportRegisterContext context)
        {
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
        public async Task<IActionResult> Update(int id, int idStatus)
        {
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
