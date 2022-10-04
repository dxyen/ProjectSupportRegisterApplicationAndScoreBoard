using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SupportRegister.Data.EF;
using SupportRegister.Data.Interfaces;
using SupportRegister.Data.Models;
using SupportRegister.ViewModels.Common;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Repository.System
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ProjectSupportRegisterContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        public UserRepository(UserManager<AppUser> userManager, ProjectSupportRegisterContext context, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(LoginRequest request)
        {
            var username = request.Username;

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim("AvatarUrl", $"{SupportRegister.Utilities.SystemConstants.SystemConstants.AppSettings.ImageUrl}/{user.Avatar}"),
                new Claim("Id", user.Id.ToString()),
                new Claim("Role", string.Join(";", roles)),
                new Claim("FullName", user.FullName != null ? user.FullName.ToString() : ""),
                new Claim("Address", user.Address != null ? user.Address.ToString(): ""),
                new Claim("DoB", user.Birthday.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber != null ? user.PhoneNumber.ToString() : ""),
                new Claim("Email", user.Email != null ? user.Email.ToString() : "")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };
            //Create SecurityKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Key"]));
            //Create SigningCredentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Create JWT with SigningCredentials
            var token = new JwtSecurityToken(
                _configuration["JwtToken:Issuer"],
                _configuration["JwtToken:Audience"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            //Return JWT string 
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> CreateAsync(AppUser entity)
        {
           return await _userManager.CreateAsync(entity, entity.PasswordHash);
        }

        public async Task<ApiResult<bool>> DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Account does not exist!!!");
            }
            await _userManager.DeleteAsync(user);
            return new ApiSuccessResult<bool>();
        }

        public async Task<AppUser> GetDetailAsync(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            return result;
        }

        public async Task<List<AppUser>> GetListAsync()
        {
            var result = await _userManager.Users.Select(x => new AppUser()
            {
                Id = x.Id,
                Address = x.Address,
                FullName = x.FullName,
                Birthday = x.Birthday,
            }).ToListAsync();
            return new List<AppUser>(result);
        }

        public async Task<ApiResult<bool>> UpdateAsync(AppUser entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Account does not exist!!!");
            }
            await _userManager.UpdateAsync(entity);
            return new ApiSuccessResult<bool>();
        }
    }
}
