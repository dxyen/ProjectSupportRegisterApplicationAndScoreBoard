using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin, staff")]
    public class UnacceptAppController : Controller
    {
        private readonly IUnaccept _unaccept;
        public UnacceptAppController()
        {
            _unaccept = RestService.For<IUnaccept>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var unaccept = _unaccept.GetAll().GetAwaiter().GetResult();
            var viewModel = new UnacceptViewModel()
            {
                unaccepts = unaccept
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
    }
}
