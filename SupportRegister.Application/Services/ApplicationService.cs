using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.Data.Models;
using SupportRegister.Utilities.Exceptions;
using SupportRegister.ViewModels.Requests.Application;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public ApplicationService(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ApplicationViewModel>> GetAllApplicationAsync()
        {
            var query = await _context.Applications
                .Select(app => new ApplicationViewModel()
                {
                    IdApplication = app.IdApplication,
                    NameApplication = app.NameApplication,
                    Description = app.Description,
                }).ToListAsync();
            return query;
        }

        public async Task<ApplicationViewModel> GetApplicationAsync(int id)
        {
            var query = await _context.Applications
                .Where(x => x.IdApplication == id)
                .Select(app => new ApplicationViewModel()
                {
                    IdApplication = app.IdApplication,
                    NameApplication = app.NameApplication,
                    Description = app.Description,
                }).FirstOrDefaultAsync();
            return query;
        }
    }
}
