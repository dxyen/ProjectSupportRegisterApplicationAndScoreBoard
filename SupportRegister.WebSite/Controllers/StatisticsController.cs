using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;

namespace SupportRegister.WebSite.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IScore _score;
        private readonly IApps _apps;
        public StatisticsController()
        {
            _score = RestService.For<IScore>("https://localhost:44363");
            _apps = RestService.For<IApps>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var CountScoreUnconfirm = _score.CountScoreUnconfirm().GetAwaiter().GetResult();
            var CountScoreUnprint = _score.CountScoreUnprint().GetAwaiter().GetResult();
            var CountAppUnconfirm = _apps.CountAppUnconfirm().GetAwaiter().GetResult();
            var CountAppUnprint = _apps.CountAppUnprint().GetAwaiter().GetResult();
            var viewModel = new StatisticViewModel()
            {
                CountScoreUnconfirm = CountScoreUnconfirm,
                CountScoreUnprint = CountScoreUnprint,
                CountAppUnconfirm = CountAppUnconfirm,
                CountAppUnprint = CountAppUnprint
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
    }
}
