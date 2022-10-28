using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using SupportRegister.ViewModels.ViewModels;
using SupportRegister.ViewModels.Requests.System.Roles;

namespace SupportRegister.WebSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _ApiRoleUri = "/api/Roles";
        private readonly HttpClient _httpClient = new HttpClient();
        public RoleController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["BaseAddress"]);
        }
        public async Task<IActionResult> Index()
        {
            var url = _ApiRoleUri + "/GetList";
            List<RoleViewModel> roles = new List<RoleViewModel>();
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    roles = JsonConvert.DeserializeObject<List<RoleViewModel>>(apiResponse);
                }
            }
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(roles);
        }
        public ViewResult CreateRole() => View();

        [HttpPost, ActionName("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var url = _ApiRoleUri + "/Create";
                using (_httpClient)
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await _httpClient.PostAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            TempData["Result"] = "Thêm thành công!";
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            ViewBag.Error = "Trùng tên!";
                            return View();
                        }
                        else
                        {
                            ViewBag.Error = "Thêm thất bại!!!";
                            return View();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            RoleViewModel role = new RoleViewModel();
            var url = _ApiRoleUri + $"/GetDetails/{id}";
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        role = JsonConvert.DeserializeObject<RoleViewModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }

            }
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateRequest model)
        {
            if (ModelState.IsValid)
            {
                var url = _ApiRoleUri + "/Update";
                using (_httpClient)
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    using (var response = await _httpClient.PutAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            TempData["Result"] = "Cập nhật thành công!";
                            ViewBag.StatusCode = response.StatusCode;
                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            ViewBag.Error = "Trùng tên!";
                            return View();
                        }
                        else
                        {
                            ViewBag.Error = "Cập nhật thất bại!!!";
                            return View();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            RoleViewModel role = new RoleViewModel();
            var url = _ApiRoleUri + $"/Delete/{id}";
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.StatusCode = response.StatusCode;
                        TempData["Result"] = "Xóa thành công";
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                        TempData["Result"] = "Xóa thất bại";
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
