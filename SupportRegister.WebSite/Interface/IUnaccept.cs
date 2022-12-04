using Refit;
using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IUnaccept
    {
        [Get("/api/Unaccept/GetAll")]
        public Task<List<UnacceptApplicationViewModel>> GetAll();
    }
}
