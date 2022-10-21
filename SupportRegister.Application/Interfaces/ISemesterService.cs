using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Application.Interfaces
{
    public interface ISemesterService
    {
        Task<SemesterViewModel> GetDetailSemesterAsync(int id);
        Task<List<SemesterViewModel>> GetAllSemesterAsync();
    }
}
