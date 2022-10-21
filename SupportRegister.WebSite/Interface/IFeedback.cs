using Refit;
using SupportRegister.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IFeedback
    {
        [Get("/api/Feedback/GetAll")]
        public Task<List<FeedbackViewModel>> GetAll();

        [Post("/api/Feedback/Create")]
        public Task<int> Create(string title_mail, string content_mail, string userId);
    }
}
