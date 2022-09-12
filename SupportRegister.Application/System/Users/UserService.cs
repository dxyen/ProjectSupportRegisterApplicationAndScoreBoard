using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SupportRegister.Data.Interfaces;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Common;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> AuthenticateAsync(LoginRequest request)
        {
            return await _userRepository.AuthenticateAsync(request);
        }

        public async Task<IdentityResult> CreateAsync(RegisterRequest request)
        {
            var user = new AppUser()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.Username,
                PasswordHash = request.Password
            };

            var result = await _userRepository.CreateAsync(user);

            return result;

        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<ApiResult<List<UserViewModel>>> GetAllUsersAsync()
        {
            var user = await _userRepository.GetListAsync();
            var result = (_mapper.Map<List<UserViewModel>>(user));
            return new ApiSuccessResult<List<UserViewModel>>(result);
        }

        public async Task<ApiResult<UserViewModel>> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetDetailAsync(id);
            var result = _mapper.Map<UserViewModel>(user);
            return new ApiSuccessResult<UserViewModel>(result);
        }

        public async Task<ApiResult<bool>> UpdateAsync(UserUpdateRequest request)
        {
            var user = _mapper.Map<AppUser>(request);
            return await _userRepository.UpdateAsync(user);
        }
    }
}
