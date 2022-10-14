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
        public async Task<int> CancelApplicationAsync(RegisterApplicationCancelRequest request)
        {
             var check = await _context.RegisterApplications.FindAsync(request.IdRegisterApplication);

            if (check == null)
            {
                throw new RegisterException($"Cannot find register with Id = {request.IdRegisterApplication}");
            }
            var application = _mapper.Map<RegisterApplication>(request);
            _context.RegisterApplications.Update(application);
            await _context.SaveChangesAsync();
            return application.IdRegisterApplication;
        }
        public async Task<List<RegisterApplicationViewModel>> GetAllApplicationByIdAsync(Guid id)
        {
            var query = await _context.DetailRegisterApplications.Include(x => x.Student)
                                                                       .ThenInclude(x => x.User)
                                                                   .Include(x => x.Regis)
                                                                       .ThenInclude(x => x.IdStatusNavigation)
                                                                   .Where(x => x.Student.User.Id == id)
                                                                   .Select(application => new RegisterApplicationViewModel()
                                                                   {
                                                                       Status = application.Regis.IdStatusNavigation.Name,
                                                                       Student = application.Student.User.FullName,
                                                                       DateRegister = application.Regis.DateRegister,
                                                                       DateReceived = application.Regis.DateReceived ?? DateTime.Now,
                                                                       PriceTotal = application.Price * application.Amount
                                                                   }).ToListAsync();
            return query;
        }

        public async Task<RegisterApplicationViewModel> GetDetailApplicationAsync(Guid id, int regisId)
        {
            var query = await _context.DetailRegisterApplications.Include(x => x.Student)
                                                                        .ThenInclude(x => x.User)
                                                                    .Include(x => x.Regis)
                                                                        .ThenInclude(x => x.IdStatusNavigation)
                                                                    .Where(x => x.Student.User.Id == id)
                                                                    .Where(x => x.Regis.IdRegisterApplication == regisId)
                                                                    .Select(application => new RegisterApplicationViewModel()
                                                                    {
                                                                        Status = application.Regis.IdStatusNavigation.Name,
                                                                        Student = application.Student.User.FullName,
                                                                        DateRegister = application.Regis.DateRegister,
                                                                        DateReceived = application.Regis.DateReceived ?? DateTime.Now,
                                                                        PriceTotal = application.Price * application.Amount
                                                                    }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<int> RegisterApplicationAsync(RegisterApplicationCreateRequest request)
        {
            var regis = _mapper.Map<RegisterApplication>(request);
            var detailRegis = _mapper.Map<DetailRegisterApplication>(request);
            _context.RegisterApplications.Add(regis);
            _context.DetailRegisterApplications.Add(detailRegis);
            await _context.SaveChangesAsync();
            return regis.IdRegisterApplication;
        }

        public async Task<int> UpdateApplicationAsync(RegisterApplicationUpdateRequest request)
        {
            var check = await _context.RegisterApplications.FindAsync(request.IdRegisterApplication);

            if (check == null)
            {
                throw new RegisterException($"Cannot find register with Id = {request.IdRegisterApplication}");
            }
            var app = _mapper.Map<RegisterApplication>(request);
            var detailApp = _mapper.Map<DetailRegisterApplication>(request);
            _context.RegisterApplications.Update(app);
            _context.DetailRegisterApplications.Update(detailApp);
            await _context.SaveChangesAsync();
            return app.IdRegisterApplication;
        }

        public async Task<List<ApplicationViewModel>> GetAllApplicationAsync()
        {
            var query = await _context.Applications
                .Select(app => new ApplicationViewModel()
                {
                    IdApplication = app.IdApplication,
                    NameApplication = app.NameApplication,
                    Description = app.Description,
                    Content = app.Content,
                    Price = app.Price,
                }).ToListAsync();
            return query;
        }
    }
}
