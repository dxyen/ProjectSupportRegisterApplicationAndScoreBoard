using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.Interfaces;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportRegister.Data.Repository.System
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleRepository(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateAsync(AppRole entity)
        {
            return await _roleManager.CreateAsync(entity);
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return new ApiErrorResult<bool>("Role does not exist!!!");
            }
            await _roleManager.DeleteAsync(role);
            return new ApiSuccessResult<bool>();
        }

        public async Task<AppRole> GetDetailAsync(Guid id)
        {
            var result = await _roleManager.FindByIdAsync(id.ToString());
            return result;
        }

        public async Task<List<AppRole>> GetListAsync()
        {
            var result = await _roleManager.Roles.Select(x => new AppRole()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
            return new List<AppRole>(result);
        }

        public async Task<ApiResult<bool>> UpdateAsync(AppRole entity)
        {
            var user = await _roleManager.FindByIdAsync(entity.Id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Account does not exist!!!");
            }
            await _roleManager.UpdateAsync(entity);
            return new ApiSuccessResult<bool>();
        }
    }
}
