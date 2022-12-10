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
            await CheckDate();
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
                new Claim("Id", user.Id.ToString()),
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
            var result = await _userManager.CreateAsync(entity, entity.PasswordHash);
            return result;
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
        public Task<List<AppUser>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> UpdateAsync(AppUser entity)
        {
            var user = await _userManager.FindByIdAsync(entity.Id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại!!!");
            }
            user.Address = entity.Address;
            user.UserName = entity.UserName;
            user.Email = entity.Email;
            user.FullName = entity.FullName;
            user.PhoneNumber = entity.PhoneNumber;
            user.Birthday = entity.Birthday;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }
        private async Task CheckDate()
        {
            //Xoa don luu, them SV vi pham
            var checkDateRegis = await _context.RegisterApplications
                                                .Include(x => x.Application)
                                                .Select(regis => new RegisterApplicationViewModel()
                                                {
                                                    IdStatus = regis.IdStatus,
                                                    DateReceived = regis.DateReceived,
                                                    DateRegister = regis.DateRegister,
                                                    Id = regis.Id,
                                                    StudentId = regis.StudentId,
                                                    NameApp = regis.Application.NameApplication
                                                }).ToListAsync();
            foreach (var item in checkDateRegis)
            {
                var checkDate = DateTime.Now - item.DateRegister;
                TimeSpan limitSave = new TimeSpan(7, 0, 0, 0);
                TimeSpan limitReceive = new TimeSpan(30, 0, 0, 0);
                var findItem = await _context.RegisterApplications.FindAsync(item.Id);
                if (checkDate >= limitSave && item.IdStatus == 4)
                {
                    _context.RegisterApplications.Remove(findItem);
                }
                else if (checkDate >= limitReceive && item.IdStatus == 5)
                {
                    var minusPoint = new MinusPoint();
                    minusPoint.NameMinus = item.NameApp;
                    minusPoint.StudentId = item.StudentId;
                    minusPoint.DateRegis = item.DateRegister;
                    await _context.MinusPoints.AddAsync(minusPoint);
                    _context.RegisterApplications.Remove(findItem);
                }
            }
            //Them sv vi pham dk in bang diem
            var checkRegisScore = await _context.DetailRegisterScoreboards
                                                .Include(x => x.Regis)
                                                .Select(regis => new RegisterScoreboardViewModel()
                                                {
                                                    idStatus = regis.Regis.IdStatus,
                                                    DateReceived = regis.Regis.DateReceived,
                                                    DateRegister = regis.Regis.DateRegister,
                                                    idStudent = regis.StudentId,
                                                    IdRegis =  regis.RegisId
                                                }).ToListAsync();
            foreach (var item in checkRegisScore)
            {
                var checkDate = DateTime.Now - item.DateRegister;
                TimeSpan limitReceive = new TimeSpan(30, 0, 0, 0);
                var findItem = await _context.RegisterScoreboards.FindAsync(item.IdRegis);
                if (checkDate >= limitReceive && item.idStatus == 5)
                {
                    var minusPoint = new MinusPoint();
                    minusPoint.NameMinus = "Đăng ký in bảng điểm";
                    minusPoint.StudentId = item.idStudent;
                    minusPoint.DateRegis = item.DateRegister;
                    await _context.MinusPoints.AddAsync(minusPoint);
                    _context.RegisterScoreboards.Remove(findItem);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
