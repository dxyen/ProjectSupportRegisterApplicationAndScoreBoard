using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SupportRegister.Data.Interfaces;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Common;
using SupportRegister.ViewModels.Requests.System.Roles;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IdentityResult> CreateAsync(RoleCreateRequest request)
        {
            var role = _mapper.Map<AppRole>(request);
            return await _unitOfWork.RoleRepository.CreateAsync(role);
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            return await _unitOfWork.RoleRepository.DeleteAsync(id);
        }

        public async Task<ApiResult<List<RoleViewModel>>> GetAllRolesAsync()
        {
            var role = await _unitOfWork.RoleRepository.GetListAsync();
            var result = _mapper.Map<List<RoleViewModel>>(role);
            return new ApiSuccessResult<List<RoleViewModel>>(result);
        }

        public async Task<ApiResult<RoleViewModel>> GetByIdAsync(Guid id)
        {
            var role = await _unitOfWork.RoleRepository.GetDetailAsync(id);
            var result = _mapper.Map<RoleViewModel>(role);
            return new ApiSuccessResult<RoleViewModel>(result);
        }

        public async Task<ApiResult<bool>> UpdateAsync(RoleUpdateRequest request)
        {
            var role = _mapper.Map<AppRole>(request);
            return await _unitOfWork.RoleRepository.UpdateAsync(role);
        }
    }
}
