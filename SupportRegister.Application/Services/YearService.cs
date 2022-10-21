using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Services
{
    public class YearService : IYearService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public YearService(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<YearViewModel>> GetAllYearAsync()
        {
            var query = await _context.Years
                .Select(year => new YearViewModel(){
                    IdYear = year.IdYear,
                    Year1 = year.Year1
                }).ToListAsync();
            return query;
        }
        public async Task<YearViewModel> GetDetailYearAsync(int id)
        {
            var query = await _context.Years
                        .Where(x => x.IdYear == id)
               .Select(year => new YearViewModel()
               {
                   IdYear = year.IdYear,
                   Year1 = year.Year1
               }).FirstOrDefaultAsync();
            return query;
        }
        public async Task<List<YearSemesterViewModel>> GetYearByNowAsync()
        {
            int now = Convert.ToInt32(DateTime.Now.Year);
            var query = await _context.YearSemesters
                        .Include(x => x.IdYearNavigation)
                        .Include(x => x.IdSemesterNavigation)
                        .Where(x => x.IdYearNavigation.Year1 <= (now))
                        .Where(x => x.IdYearNavigation.Year1 >= (now - 9))
                        .OrderByDescending(x => x.Id)
               .Select(data => new YearSemesterViewModel()
               {
                    Id = data.Id,
                    Year = data.IdYearNavigation.Year1,
                    YearSemester = data.YearSemester1
               }).ToListAsync();
            return query;
        }
    }
}
