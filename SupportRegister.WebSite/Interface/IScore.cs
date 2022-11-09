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
        public Task<int> Update(int id, int idStatus, int idStudent);

        [Post("/api/Scoreboard/Delete")]
        public Task<int> Delete(int id);

        [Get("/api/Scoreboard/GetAllScoreUnconfirm")]
        public Task<List<RegisterScoreboardViewModel>> GetAllScoreUnconfirm();

        [Get("/api/Scoreboard/CountScoreUnconfirm")]
        public Task<int> CountScoreUnconfirm();

        [Get("/api/Scoreboard/GetAllScoreUnprint")]
        public Task<List<RegisterScoreboardViewModel>> GetAllScoreUnprint();

        [Get("/api/Scoreboard/CountScoreUnprint")]
        public Task<int> CountScoreUnprint();
    }
}
