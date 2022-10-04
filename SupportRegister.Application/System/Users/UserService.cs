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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<string> AuthenticateAsync(LoginRequest request)
        {
            return await _unitOfWork.UserRepository.AuthenticateAsync(request);
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

            var result = await _unitOfWork.UserRepository.CreateAsync(user);

            return result;

        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            return await _unitOfWork.UserRepository.DeleteAsync(id);
        }

        public async Task<ApiResult<List<UserViewModel>>> GetAllUsersAsync()
        {
            var user = await _unitOfWork.UserRepository.GetListAsync();
            var result = _mapper.Map<List<UserViewModel>>(user);

            return new ApiSuccessResult<List<UserViewModel>>(result);
        }

        public async Task<ApiResult<UserViewModel>> GetByIdAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetDetailAsync(id);
            var result = _mapper.Map<UserViewModel>(user);
            return new ApiSuccessResult<UserViewModel>(result);
        }

        public async Task<ApiResult<bool>> UpdateAsync(UserUpdateRequest request)
        {
            var user = _mapper.Map<AppUser>(request);
            return await _unitOfWork.UserRepository.UpdateAsync(user);
        }
        public async Task<bool> CheckPassword(AccountChangePassword loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            if (user == null) return false;
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);
            return result.Equals(PasswordVerificationResult.Success);
        }

        public async Task<bool> ChangePassword(AccountChangePassword accountChange)
        {
            var user = await _userManager.FindByNameAsync(accountChange.Username);
            if (user == null) return false;

            var result = await _userManager.ChangePasswordAsync(user, accountChange.PasswordCurrent, accountChange.PasswordNew);

            return result.Succeeded;
        }

    }
}
