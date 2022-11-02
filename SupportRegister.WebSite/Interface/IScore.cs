using Refit;
using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IScore
    {
        [Get("/api/Scoreboard/GetDetail/{scoreId}")]
        public Task<RegisterScoreboardViewModel> GetDetail(int scoreId);

        [Get("/api/Scoreboard/GetAll")]
        public Task<List<RegisterScoreboardViewModel>> GetAll();

        [Post("/api/Scoreboard/Update")]
        public Task<int> Update(int id, int idStatus);

        [Post("/api/Scoreboard/Delete")]
        public Task<int> Delete(int id);
    }
}
