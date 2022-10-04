using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SupportRegister.Application.System.Users;
using SupportRegister.Utilities.SystemConstants;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountsController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserViewModel user = new UserViewModel();
            using (var client = _httpClientFactory.CreateClient("apiBaseAddress"))
            {
                var result = await client.GetAsync($"Users/GetByIdAsync/{User.Identity.Name}");

                if (result.IsSuccessStatusCode)
                {
                    //user = await result.Content.ReadAsAsync<UserViewModel>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                        "Không tìm thấy User, vui lòng kiểm tra lại thông tin");
                }
            }

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = _httpClientFactory.CreateClient("apiBaseAddress"))
            {
                var response = await client.PostAsync("Users/Authenticate", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(token))
                    {
                        TempData["Message"] = "Username or Password incorrect";
                        return View(request);
                    }

                    ClaimsPrincipal userPrincipal = ValidateToken(token);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        IsPersistent = request.RememberMe
                    };
                    await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                userPrincipal,
                                authProperties);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["JwtToken:Audience"];
            validationParameters.ValidIssuer = _configuration["JwtToken:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Accounts");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(AccountChangePassword accountChange)
        {
            if (!ModelState.IsValid)
            {
                return View(accountChange);
            }

            accountChange.Username = User.Identity.Name;
            accountChange.Password = accountChange.PasswordCurrent;

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(accountChange), Encoding.UTF8, "application/json");

            using (var httpClient = _httpClientFactory.CreateClient("apiBaseAddress"))
            {
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("Users/CheckPassword", httpContent);
                string currentPasswordIsValid = await httpResponseMessage.Content.ReadAsStringAsync();

                if (currentPasswordIsValid.Equals("true"))
                {
                    if (accountChange.PasswordCurrent.Equals(accountChange.PasswordNew))
                    {
                        ModelState.AddModelError("1", "Mật khẩu mới trùng với mật khẩu hiện tại!");
                    }
                    else if (accountChange.PasswordNew.Equals(accountChange.PasswordNewComfirm))
                    {
                        var newhttpResponseMessage = await httpClient.PostAsync("Users/ChangePassword", httpContent);
                        var isChanged = await newhttpResponseMessage.Content.ReadAsStringAsync();
                        if (isChanged.Equals("true"))
                        {
                            return await LogOut();
                        }
                        else
                        {
                            ModelState.AddModelError("2", "Đã có lỗi trong quá trình lưu, vui lòng thử lại!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("3", "Xác nhận mật khẩu mới không khớp!");
                    }
                }
                else
                {
                    ModelState.AddModelError("4", "Mật khẩu cũ không chính xác!!!");
                }
            }

            return View(accountChange);
        }
    }
}
