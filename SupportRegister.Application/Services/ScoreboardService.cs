using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.Data.Models;
using SupportRegister.Utilities.Exceptions;
using SupportRegister.ViewModels.Requests.Scoreboard;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Services
{
    public class ScoreboardService : IScoreboardService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public ScoreboardService(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CancelScoreboardAsync(RegisterScoreboardCancelRequest request)
        {
            var check = await _context.RegisterScoreboards.FindAsync(request.IdRegisterScoreboard);

            if (check == null)
            {
                throw new RegisterException($"Cannot find register with Id = {request.IdRegisterScoreboard}");
            }
            var scoreboard = _mapper.Map<RegisterScoreboard>(request);
            _context.RegisterScoreboards.Update(scoreboard);
            await _context.SaveChangesAsync();
            return scoreboard.IdRegisterScoreboard;
        }
        //private int GetPriceTotal(Guid userId, int regisId)
        //{
        //    //var query = (from D in _context.DetailRegisterScoreboards
        //    //                  join R in _context.RegisterScoreboards on D.IdRegisterScoreboard equals R.IdRegisterScoreboard
        //    //                  join S in _context.Students on R.StudentId equals S.StudentId
        //    //                  join U in _context.Users on S.UserId equals U.Id
        //    //                  where U.Id == userId
        //    //                  where R.IdRegisterScoreboard == regisId
        //    //                  group D.Price by new { R.IdRegisterScoreboard }
        //    //                        into DGroup
        //    //                  select new
        //    //                  {
        //    //                      IdRegis = DGroup.Key.IdRegisterScoreboard,
        //    //                      PriceTotal = DGroup.Sum()
        //    //                  }).FirstOrDefault();
        //    //int PriceTotal = Convert.ToInt32(query.PriceTotal);
        //    return 0;
        //}
        public async Task<RegisterScoreboardViewModel> GetDetailScoreboardByIdAsync(Guid id, int regisId)
        {
            var query = await _context.DetailRegisterScoreboards.Include(x => x.Student)
                                                                .ThenInclude(x => x.User)
                                                            .Include(x => x.Regis)
                                                            .Include(x => x.Semester)
                                                            .Include(x => x.Year)
                                                            .Where(x => x.Student.User.Id == id)
                                                            .Where(x => x.Regis.IdRegisterScoreboard == regisId)
                                                            .Select(Score => new RegisterScoreboardViewModel()
                                                            {
                                                                Status = Score.Regis.IdStatusNavigation.Name,
                                                                Semester = Score.Semester.NameSemester,
                                                                Year = Score.Year.Year1,
                                                                Student = Score.Student.User.FullName,
                                                                DateRegister = Score.Regis.DateRegister,
                                                                DateReceived = Score.Regis.DateReceived ?? DateTime.Now,
                                                                PriceTotal = Score.Price * Score.Amount
                                                            }).FirstOrDefaultAsync();
            return query;
        }
        public async Task<List<RegisterScoreboardViewModel>> GetAllScoreboardByIdAsync(Guid id)
        {
            var query = await _context.DetailRegisterScoreboards.Include(x => x.Student)
                                                     .ThenInclude(x => x.User)
                                                 .Include(x => x.Regis)
                                                 .Include(x => x.Semester)
                                                 .Include(x => x.Year)
                                                 .Where(x => x.Student.User.Id == id)
                                                 .Select(Score => new RegisterScoreboardViewModel()
                                                 {
                                                     Status = Score.Regis.IdStatusNavigation.Name,
                                                     Semester = Score.Semester.NameSemester,
                                                     Year = Score.Year.Year1,
                                                     Student = Score.Student.User.FullName,
                                                     DateRegister = Score.Regis.DateRegister,
                                                     DateReceived = Score.Regis.DateReceived ?? DateTime.Now,
                                                     PriceTotal = Score.Price * Score.Amount
                                                 }).ToListAsync();
            return query;
        }
        public async Task<int> RegisterScoreboardAsync(RegisterScoreboardCreateRequest request)
        {
            var registerScoreboard = _mapper.Map<RegisterScoreboard>(request);
            var detailRegister = _mapper.Map<DetailRegisterScoreboard>(request);
            _context.RegisterScoreboards.Add(registerScoreboard);
            _context.DetailRegisterScoreboards.Add(detailRegister);
            await _context.SaveChangesAsync();
            return registerScoreboard.IdRegisterScoreboard;
        }

        public async Task<int> UpdateScoreboardAsync(RegisterScoreboardUpdateRequest request)
        {
            var check = await _context.RegisterScoreboards.FindAsync(request.IdRegisterScoreboard);

            if (check == null)
            {
                throw new RegisterException($"Cannot find register with Id = {request.IdRegisterScoreboard}");
            }
            var scoreboard = _mapper.Map<RegisterScoreboard>(request);
            var detailRegister = _mapper.Map<DetailRegisterScoreboard>(request);
            _context.RegisterScoreboards.Update(scoreboard);
            _context.DetailRegisterScoreboards.Update(detailRegister);
            await _context.SaveChangesAsync();
            return scoreboard.IdRegisterScoreboard;
        }
    }
}
