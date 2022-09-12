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

            // check email is match if user type email
            var emailCheck = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email == request.Username);
            if (emailCheck != null)
            {
                username = emailCheck.UserName;
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
                new Claim("AvatarUrl", $"{SupportRegister.Utilities.SystemConstants.SystemConstants.AppSettings.ImageUrl}/{user.Avatar}"),
                new Claim("Id", user.Id.ToString()),
                new Claim("Role", string.Join(";", roles)),
                new Claim("UserName", user.UserName.ToString()),
                new Claim("FullName", user.FullName != null ? user.FullName.ToString() : ""),
                new Claim("Address", user.Address != null ? user.Address.ToString(): ""),
                new Claim("DoB", user.Birthday.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber != null ? user.PhoneNumber.ToString() : ""),
                new Claim("Email", user.Email != null ? user.Email.ToString() : "")
            };

            string issuer = _configuration["Tokens:Issuer"];
            string signingKey = _configuration["Tokens:Key"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> CreateAsync(AppUser entity)
        {
           return await _userManager.CreateAsync(entity);
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

        public async Task<ApiResult<AppUser>> GetDetailAsync(Guid id)
        {
            var result = await _userManager.FindByIdAsync(id.ToString());
            return new ApiSuccessResult<AppUser>(result);
        }

        public async Task<ApiResult<List<AppUser>>> GetListAsync()
        {
            var result = await _userManager.Users.ToListAsync();
            return new ApiSuccessResult<List<AppUser>>(result);
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
