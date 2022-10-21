using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SupportRegister.ViewModels.Requests.System.Users;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly string _ApiUri = "/api/Users";
        private readonly HttpClient _httpClient = new HttpClient();

        public AccountsController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpClient.BaseAddress = new Uri(_configuration["BaseAddress"]);
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
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var url = _ApiUri + "/GetAllUsers";
            List<UserViewModel> users = new List<UserViewModel>();
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<UserViewModel>>(apiResponse);
                }
            }
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(users);
        }
        //update
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var url = _ApiUri + $"/GetDetails/{id}";
            UserViewModel user = new UserViewModel();
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateRequest model)
        {
            var url = _ApiUri + "/Update";
            using (_httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var response = await _httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        TempData["Result"] = "Chỉnh sửa thành công!";
                        ViewBag.StatusCode = response.StatusCode;
                    }
                    else
                    {
                        TempData["Result"] = "Chỉnh sửa thất bại!";
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
            }
            return RedirectToAction("GetAll");
        }
        //add
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var url = $"/api/Roles/GetList";
            IEnumerable<RoleViewModel> role = Enumerable.Empty<RoleViewModel>();
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    role = JsonConvert.DeserializeObject< IList<RoleViewModel>>(apiResponse);
                }
            }
            ViewData["RoleId"] = new SelectList(role, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var url = _ApiUri + "/register";
                using (_httpClient)
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await _httpClient.PostAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            TempData["Result"] = "Tạo mới thành công!";
                            ViewBag.StatusCode = response.StatusCode;
                        }
                        else
                        {
                            TempData["Result"] = "Tạo mới thất bại!";
                            ViewBag.StatusCode = response.StatusCode;
                        }
                    }
                }
                return RedirectToAction("GetAll");
            }
            else
            {
                return View();
            }
        }
    }
}
