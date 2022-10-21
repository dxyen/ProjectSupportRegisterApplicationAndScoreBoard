using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Application.Interfaces;
using SupportRegister.Data.EF;
using SupportRegister.Data.Models;
using SupportRegister.Utilities.Exceptions;
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

        public async Task<int> DeleteFeedbackAsync(FeedbackDeleteRequest request)
        {
            var feedback = await _context.Feedbacks.Where(x => x.IdFeedback == request.IdFeedback).FirstOrDefaultAsync();
            if (feedback == null)
            {
                throw new RegisterException($"Cannot find feedback with Id: {request.IdFeedback}");
            }
            _context.Feedbacks.Remove(feedback);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<FeedbackViewModel>> GetAllFeedbackAsync()
        {
            var query = await _context.Feedbacks.Include(x => x.Student)
                                                    .ThenInclude(x => x.User)
                                                .Select(feedback => new FeedbackViewModel()
                                                {
                                                    ContentFeedback = feedback.ContentFeedback,
                                                    StudentId = feedback.StudentId,
                                                    Student = feedback.Student.User.FullName
                                                }).ToListAsync();
            return query;
        }

        public async Task<List<FeedbackViewModel>> GetAllFeedbackByIdAsync(Guid id)
        {
            var query = await _context.Feedbacks.Include(x => x.Student)
                                                   .ThenInclude(x => x.User)
                                                .Where(x => x.Student.User.Id == id)
                                               .Select(feedback => new FeedbackViewModel()
                                               {
                                                   ContentFeedback = feedback.ContentFeedback,
                                                   StudentId = feedback.StudentId,
                                                   Student = feedback.Student.User.FullName
                                               }).ToListAsync();
            return query;
        }

        public async Task<int> UpdateFeedbackAsync(FeedbackUpdateRequest request)
        {
            var feedback = _mapper.Map<Feedback>(request);
            _context.Feedbacks.Update(feedback);
            return await _context.SaveChangesAsync();
    
        }
    }
}
