using AutoMapper;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Requests.Feedback;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        protected ProjectSupportRegisterContext _context;
        private readonly IMapper _mapper;

        public FeedbackService(ProjectSupportRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CreateFeedbackAsync(FeedbackCreateRequest request)
        {
            var feedback = _mapper.Map<Feedback>(request);
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback.IdFeedback;
        }

        public Task<int> DeleteFeedbackAsync(FeedbackDeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<FeedbackViewModel>> GetAllScoreboardAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<FeedbackViewModel>> GetAllScoreboardByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFeedbackAsync(FeedbackUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
