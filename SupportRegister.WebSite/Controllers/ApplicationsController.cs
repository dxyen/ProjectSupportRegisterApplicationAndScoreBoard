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
        private readonly IRegisApp _regisApp;
        public ApplicationsController()
        {
            _apps = RestService.For<IApps>("https://localhost:44363");
            _regisApp = RestService.For<IRegisApp>("https://localhost:44363");
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
        public IActionResult GetAllAppUnconfirm()
        {
            var apps = _apps.GetAllAppUnconfirm().GetAwaiter().GetResult();
            var viewModel = new AppsViewModel()
            {
                apps = apps,
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        public IActionResult GetAllAppUnprint()
        {
            var apps = _apps.GetAllAppUnprint().GetAwaiter().GetResult();
            var viewModel = new AppsViewModel()
            {
                apps = apps,
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
        public IActionResult UpdateStatus(int id, int idStatus)
        {
            var result = _apps.Update(id, idStatus).GetAwaiter().GetResult();
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
        public IActionResult Delete(int id)
        {
            var result = _apps.Delete(id).GetAwaiter().GetResult();
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
        [HttpGet]
        public IActionResult PrintApp(string userId, int id)
        {
            var app = _regisApp.Update(id).GetAwaiter().GetResult();
            var student = _regisApp.GetStudentApp(userId).GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
                appRegis = app,
                students = student
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
    }
}
