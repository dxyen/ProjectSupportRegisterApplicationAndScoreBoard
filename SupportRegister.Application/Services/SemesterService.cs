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
    public class SemesterService : ISemesterService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public SemesterService(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SemesterViewModel>> GetAllSemesterAsync()
        {
            var query = await _context.Semesters
                .Select(semester => new SemesterViewModel()
                {
                    IdSemester = semester.IdSemester,
                    NameSemester = semester.NameSemester
                }).ToListAsync();
            return query;
        }

        public async Task<SemesterViewModel> GetDetailSemesterAsync(int id)
        {
            var query = await _context.Semesters
               .Select(semester => new SemesterViewModel()
               {
                   IdSemester = semester.IdSemester,
                   NameSemester = semester.NameSemester
               }).FirstOrDefaultAsync();
            return query;
        }
    }
}
