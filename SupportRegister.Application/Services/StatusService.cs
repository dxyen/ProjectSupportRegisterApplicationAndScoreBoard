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
    public class StatusService : IStatusService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public StatusService(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<StatusViewModel>> GetAllStatusAsync()
        {
            var query = await _context.Statuses
                .Select(status => new StatusViewModel()
                {
                    IdStatus = status.Id,
                    NameStatus = status.Name
                }).ToListAsync();
            return query;
        }

        public async Task<StatusViewModel> GetDetailStatusAsync(int id)
        {
            var query = await _context.Statuses.Where(x => x.Id == id)
            .Select(status => new StatusViewModel()
            {
                IdStatus = status.Id,
                NameStatus = status.Name
            }).FirstOrDefaultAsync();
            return query;
        }
    }
}
