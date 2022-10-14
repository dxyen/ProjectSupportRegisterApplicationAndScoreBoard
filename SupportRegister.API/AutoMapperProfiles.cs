using AutoMapper;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Requests.Application;
using SupportRegister.ViewModels.Requests.Feedback;
using SupportRegister.ViewModels.Requests.Scoreboard;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;

namespace SupportRegister.API
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region User
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<AppUser, UserUpdateRequest>().ReverseMap();
            #endregion
            #region Role
            CreateMap<AppRole, RoleViewModel>().ReverseMap();
            //CreateMap<AppRole, >().ReverseMap();
            #endregion
            #region RegisterScoreboard
            CreateMap<RegisterScoreboard, RegisterScoreboardViewModel>().ReverseMap();
            CreateMap<RegisterScoreboardCreateRequest, RegisterScoreboard>().ReverseMap();
            CreateMap<RegisterScoreboardCancelRequest, RegisterScoreboard>().ReverseMap();
            CreateMap<RegisterScoreboardUpdateRequest, RegisterScoreboard>().ReverseMap();
            #endregion
            #region RegisterScoreboard
            CreateMap<RegisterApplication, RegisterApplicationViewModel>().ReverseMap();
            CreateMap<RegisterApplicationCreateRequest, RegisterApplication>().ReverseMap();
            CreateMap<RegisterApplicationCancelRequest, RegisterApplication>().ReverseMap();
            CreateMap<RegisterApplicationUpdateRequest, RegisterApplication>().ReverseMap();
            #endregion
            #region Semester
            CreateMap<Semester, SemesterViewModel>().ReverseMap();
            #endregion
            #region Year
            CreateMap<Year, YearViewModel>().ReverseMap();
            #endregion
            #region Feedback
            CreateMap<Feedback, FeedbackViewModel>().ReverseMap();
            CreateMap<Feedback, FeedbackDeleteRequest>().ReverseMap();
            CreateMap<Feedback, FeedbackUpdateRequest>().ReverseMap();
            CreateMap<Feedback, FeedbackCreateRequest>().ReverseMap();
            #endregion
        }
    }
}
