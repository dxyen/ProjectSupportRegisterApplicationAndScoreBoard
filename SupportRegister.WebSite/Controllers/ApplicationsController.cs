using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin, staff")]
    public class ApplicationsController : Controller
    {
        private readonly IApps _apps;
        public ApplicationsController()
        {
            _apps = RestService.For<IApps>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var app = _apps.GetAll().GetAwaiter().GetResult();
            var viewModel = new AppsViewModel()
            {
                apps = app,
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Update(int appId, int studentId)
        {
            var app = _apps.GetDetail(appId, studentId).GetAwaiter().GetResult();
            var viewModel = new AppsViewModel()
            {
                appDetail = app,
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(int id, int idStatus, int idStudent)
        {
            var result = _apps.Update(id, idStudent, idStatus).GetAwaiter().GetResult();
            if (result >= 1)
            {
                TempData["Result"] = "Đã cập nhật trạng thái thành công!";
            }
            else
            {
                TempData["Result"] = "Đã cập nhật trạng thái thất bại!";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int appId, int studentId)
        {
            var result = _apps.Delete(appId, studentId).GetAwaiter().GetResult();
            if (result >= 1)
            {
                TempData["Result"] = "Đã xóa thành công!";
            }
            else
            {
                TempData["Result"] = "Đã xóa thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}
