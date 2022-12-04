using Refit;
using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IApps
    {
        [Get("/api/Application/GetDetail")]
        public Task<RegisterApplicationViewModel> GetDetail(int appId, int studentId);

        [Get("/api/Application/GetAll")]
        public Task<List<RegisterApplicationViewModel>> GetAll();

        [Post("/api/Application/Update")]
        public Task<int> Update(int id, int idStatus);

        [Post("/api/Application/Delete")]
        public Task<int> Delete(int id);

        [Get("/api/Application/GetAllAppUnconfirm")]
        public Task<List<RegisterApplicationViewModel>> GetAllAppUnconfirm();

        [Get("/api/Application/CountAppUnconfirm")]
        public Task<int> CountAppUnconfirm();

        [Get("/api/Application/GetAllAppUnprint")]
        public Task<List<RegisterApplicationViewModel>> GetAllAppUnprint();

        [Get("/api/Application/CountAppUnprint")]
        public Task<int> CountAppUnprint();
    }
}
