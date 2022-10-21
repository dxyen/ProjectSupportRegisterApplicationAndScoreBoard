using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Requests.Scoreboard;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Interfaces
{
    public interface IScoreboardService
    {
        Task<int> RegisterScoreboardAsync(RegisterScoreboardCreateRequest request);
        Task<int> UpdateScoreboardAsync(RegisterScoreboardUpdateRequest request);
        Task<int> CancelScoreboardAsync(RegisterScoreboardCancelRequest request);
        Task<RegisterScoreboardViewModel> GetDetailScoreboardByIdAsync(Guid id, int regisId);
        Task<List<RegisterScoreboardViewModel>> GetAllScoreboardByIdAsync(Guid id);
    }
}
