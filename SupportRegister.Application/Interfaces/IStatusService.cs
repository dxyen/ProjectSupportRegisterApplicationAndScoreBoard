using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Interfaces
{
    public interface IStatusService
    {
        Task<StatusViewModel> GetDetailStatusAsync(int id);
        Task<List<StatusViewModel>> GetAllStatusAsync();
    }
}
