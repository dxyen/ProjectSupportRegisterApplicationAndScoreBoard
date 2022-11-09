using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin, staff")]
    public class ScoreboardsController : Controller
    {
        private readonly IScore _score;
        public ScoreboardsController()
        {
            _score = RestService.For<IScore>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var score = _score.GetAll().GetAwaiter().GetResult();
            var viewModel = new ScoresViewModel()
            {
                scores = score,
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        public IActionResult GetAllScoreUnconfirm()
        {
            var score = _score.GetAllScoreUnconfirm().GetAwaiter().GetResult();
            var viewModel = new ScoresViewModel()
            {
                scores = score,
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        public IActionResult GetAllScoreUnprint()
        {
            var score = _score.GetAllScoreUnprint().GetAwaiter().GetResult();
            var viewModel = new ScoresViewModel()
            {
                scores = score,
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Update(int scoreId)
        {
            var score = _score.GetDetail(scoreId).GetAwaiter().GetResult();
            var viewModel = new ScoresViewModel()
            {
                scoreDetail = score,
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
            var result = _score.Update(id, idStatus, idStudent).GetAwaiter().GetResult();
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
            var result = _score.Delete(id).GetAwaiter().GetResult();
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
