using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;
using System.Linq;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "student")]
    public class RegisterScoreboardController : Controller
    {
        private readonly IRegisScore _regisScore;
        public RegisterScoreboardController()
        {
            _regisScore = RestService.For<IRegisScore>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var years = _regisScore.GetAllYearNow().GetAwaiter().GetResult();
            var student = _regisScore.GetAllStudent(userId).GetAwaiter().GetResult();
            var regisStu = _regisScore.GetAllRegisScore(userId).GetAwaiter().GetResult();
            var viewModel = new RegisScoreViewModel()
            {
                years = years,
                students = student,
                regisStu = regisStu
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(string option, int yearstart_stu, int yearend_stu, int id_start, int id_end, int soluong)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var student = _regisScore.Create(option, yearstart_stu, yearend_stu, id_start, id_end, soluong, userId).GetAwaiter().GetResult();
            if (student >= 2)
            {
                TempData["Result"] = "Đăng ký thành công!";
            }
            else
            {
                TempData["Result"] = "Đăng ký thất bại!";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Cancel(int cancelId)
        {
            var result = _regisScore.Cancel(cancelId).GetAwaiter().GetResult();
            if (result >= 1)
            {
                TempData["Result"] = "Đã hủy yêu cầu thành công!";
            }
            else
            {
                TempData["Result"] = "Đã hủy yêu cầu thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}
