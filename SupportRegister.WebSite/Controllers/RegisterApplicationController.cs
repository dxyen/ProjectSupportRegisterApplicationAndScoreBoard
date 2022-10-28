using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;
using System.Linq;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "student")]
    public class RegisterApplicationController : Controller
    {
        private readonly IRegisApp _regisApp;
        public RegisterApplicationController()
        {
            _regisApp = RestService.For<IRegisApp>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var idUser = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var regis = _regisApp.GetAllRegis(idUser).GetAwaiter().GetResult();
            var app = _regisApp.GetAll().GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
                app = app,
                allAppRegis = regis
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        public IActionResult Application2(int id)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var app = _regisApp.GetDetail(id).GetAwaiter().GetResult();
            var student = _regisApp.GetStudentApp(userId).GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
                appDetails = app,
                students = student
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Store(string content, string title, int id)
        {
            string response = "";
            try
            {
                var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                var app = _regisApp.Store(content, title, id, userId).GetAwaiter().GetResult();
                if (app >= 1)
                {
                    response = "Lưu đơn thành công!";
                    return Ok(response);
                }
                else
                {
                    response = "Lưu đơn thất bại!";
                    return BadRequest(response);
                }
            }
            catch (System.Exception e)
            {
                var exception = e.Message;
                return StatusCode(500, exception); 
            }
           
        }
        [HttpPost]
        public IActionResult Submit(string content, string title, int id)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var app = _regisApp.Submit(content, title, id, userId).GetAwaiter().GetResult();
            if (app >= 1)
            {
                TempData["Result"] = "Đăng ký đơn thành công!";
            }
            else
            {
                TempData["Result"] = "Đăng ký đơn thất bại!";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateApplication2()
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            int idApp = 2;
            int idStatus = 4;
            var update = _regisApp.Update(idApp, userId, idStatus).GetAwaiter().GetResult();
            var app = _regisApp.GetDetail(idApp).GetAwaiter().GetResult();
            var student = _regisApp.GetStudentApp(userId).GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
                appDetails = app,
                students = student,
                appRegis = update
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Cancel(int cancelId)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var result = _regisApp.Cancel(cancelId, userId).GetAwaiter().GetResult();
            if (result >= 1)
            {
                TempData["Result"] = "Đã xóa đơn thành công!";
            }
            else
            {
                TempData["Result"] = "Đã đơn thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}
