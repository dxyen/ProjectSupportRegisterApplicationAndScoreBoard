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
        public IActionResult Application4(int id)
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
        public IActionResult Application5(int id)
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
        public IActionResult Store(string content, string title, int id, int idRegis)
        {
            string response = "";
            try
            {
                var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                var app = _regisApp.Store(content, title, id, userId, idRegis).GetAwaiter().GetResult();
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
        public IActionResult Submit(string content, string title, int id, int idRegis)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var app = _regisApp.Submit(content, title, id, userId, idRegis).GetAwaiter().GetResult();
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
        public IActionResult UpdateApplication2(int id)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var update = _regisApp.Update(id).GetAwaiter().GetResult();
            var student = _regisApp.GetStudentApp(userId).GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
                students = student,
                appRegis = update
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult UpdateApplication5(int id)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var update = _regisApp.Update(id).GetAwaiter().GetResult();
            var student = _regisApp.GetStudentApp(userId).GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
                students = student,
                appRegis = update
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult UpdateApplication4(int id)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var update = _regisApp.Update(id).GetAwaiter().GetResult();
            var student = _regisApp.GetStudentApp(userId).GetAwaiter().GetResult();
            var viewModel = new RegisAppViewModel()
            {
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
            var result = _regisApp.Cancel(cancelId).GetAwaiter().GetResult();
            if (result >= 1)
            {
                TempData["Result"] = "Đã xóa đơn thành công!";
            }
            else
            {
                TempData["Result"] = "Xóa đơn thất bại!";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Receive(int receiveId)
        {
            var result = _regisApp.Receive(receiveId).GetAwaiter().GetResult();
            if (result >= 1)
            {
                TempData["Result"] = "Đơn đã được xác nhận!";
            }
            else
            {
                TempData["Result"] = "Xác nhận thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}
