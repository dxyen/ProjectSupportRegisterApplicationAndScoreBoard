using SupportRegister.ViewModels.Requests.Application;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Interfaces
{
    public interface IApplicationService
    {
        Task<int> RegisterApplicationAsync(RegisterApplicationCreateRequest request);
        Task<int> UpdateApplicationAsync(RegisterApplicationUpdateRequest request);
        Task<int> CancelApplicationAsync(RegisterApplicationCancelRequest request);
        Task<RegisterApplicationViewModel> GetDetailApplicationAsync(Guid id, int regisId);
        Task<List<RegisterApplicationViewModel>> GetAllApplicationByIdAsync(Guid id);

        Task<List<ApplicationViewModel>> GetAllApplicationAsync();
    }
}
