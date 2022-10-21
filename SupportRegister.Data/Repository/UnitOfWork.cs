using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SupportRegister.Data.EF;
using SupportRegister.Data.Interfaces;
using SupportRegister.Data.Models;
using SupportRegister.Data.Repository.System;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        public UnitOfWork(ProjectSupportRegisterContext context, IMapper mapper, 
                RoleManager<AppRole> roleManager, UserManager<AppUser> userManager,
                SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_userManager, _context, _signInManager, _configuration);
                }
                return _userRepository;
            }
        }
        public IRoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new RoleRepository(_roleManager);
                }
                return _roleRepository;
            }
        }
        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        #endregion
    }
}
