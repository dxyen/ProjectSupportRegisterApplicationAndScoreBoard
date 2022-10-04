using Microsoft.AspNetCore.Identity;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Common;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(AppUser entity);
        Task<string> AuthenticateAsync(LoginRequest entity);
        Task<ApiResult<bool>> UpdateAsync(AppUser entity);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
        Task<AppUser> GetDetailAsync(Guid id);
        Task<List<AppUser>> GetListAsync();
    }
}
