using AutoMapper;
using SupportRegister.Data.Models;
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
        }
    }
}
