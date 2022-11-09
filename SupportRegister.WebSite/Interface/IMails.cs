using Refit;
using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IMails
    {
        [Get("/api/Email/GetAll")]
        public Task<List<EmailAdminViewModel>> GetAll();

        [Get("/api/Email/GetDetail/{id}")]
        public Task<EmailAdminViewModel> GetDetail(int id);

        [Post("/api/Email/Update")]
        public Task<int> Update(int id, string name, string email, string password);
    }
}
