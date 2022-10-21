using SupportRegister.ViewModels.Requests.Feedback;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<int> CreateFeedbackAsync(FeedbackCreateRequest request);
        Task<int> UpdateFeedbackAsync(FeedbackUpdateRequest request);
        Task<int> DeleteFeedbackAsync(FeedbackDeleteRequest request);
        Task<List<FeedbackViewModel>> GetAllFeedbackByIdAsync(Guid id);
        Task<List<FeedbackViewModel>> GetAllFeedbackAsync();
    }
}
