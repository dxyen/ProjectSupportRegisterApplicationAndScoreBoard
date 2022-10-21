using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SupportRegister.WebSite.Controllers
{
    [Authorize(Roles = "student")]
    public class RegisterApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Application()
        {
            return View();
        }
    }
}
