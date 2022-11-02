using Microsoft.AspNetCore.Mvc;

namespace SupportRegister.WebSite.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
