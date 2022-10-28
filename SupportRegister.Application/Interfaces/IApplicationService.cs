using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Application.Interfaces
{
    public interface IApplicationService
    {
        Task<List<ApplicationViewModel>> GetAllApplicationAsync();
        Task<ApplicationViewModel> GetApplicationAsync(int id);
    }
}
