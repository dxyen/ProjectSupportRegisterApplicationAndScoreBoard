using Microsoft.AspNetCore.Identity;
using SupportRegister.ViewModels.Common;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Application.System.Users
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(LoginRequest request);
        Task<IdentityResult> CreateAsync(RegisterRequest request);
        Task<ApiResult<List<UserViewModel>>> GetAllUsersAsync();
        Task<ApiResult<UserViewModel>> GetByIdAsync(Guid id);
        Task<ApiResult<bool>> UpdateAsync(UserUpdateRequest request);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
        Task<bool> CheckPassword(AccountChangePassword loginUser);
        Task<bool> ChangePassword(AccountChangePassword accountChange);

    }
}
