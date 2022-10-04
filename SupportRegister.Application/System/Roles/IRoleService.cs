using Microsoft.AspNetCore.Identity;
using SupportRegister.ViewModels.Common;
using SupportRegister.ViewModels.Requests.System.Roles;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Application.System.Roles
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateAsync(RoleCreateRequest request);
        Task<ApiResult<List<RoleViewModel>>> GetAllRolesAsync();
        Task<ApiResult<RoleViewModel>> GetByIdAsync(Guid id);
        Task<ApiResult<bool>> UpdateAsync(RoleUpdateRequest request);

        Task<ApiResult<bool>> DeleteAsync(Guid id);
    }
}
