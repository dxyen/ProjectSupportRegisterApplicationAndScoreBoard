using Microsoft.AspNetCore.Identity;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateAsync(AppRole entity);
        Task<ApiResult<bool>> UpdateAsync(AppRole entity);
        Task<ApiResult<bool>> DeleteAsync(Guid id);
        Task<AppRole> GetDetailAsync(Guid id);
        Task<List<AppRole>> GetListAsync();
    }
}
