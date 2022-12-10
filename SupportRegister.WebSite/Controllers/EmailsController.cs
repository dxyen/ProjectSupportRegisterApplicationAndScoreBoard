using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using SupportRegister.WebSite.Models;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "admin")]
    public class EmailsController : Controller
    {
        private readonly IMails _mails;
        public EmailsController()
        {
            _mails = RestService.For<IMails>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            var mail = _mails.GetAll().GetAwaiter().GetResult();
            var viewModel = new MailViewModel()
            {
                mails = mail
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var mail = _mails.GetDetail(id).GetAwaiter().GetResult();
            var viewModel = new MailViewModel()
            {
                mail = mail
            };
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(int id, string name, string email, string password)
        {
            var mail = _mails.Update(id, name, email, password).GetAwaiter().GetResult();
            if (mail >= 1)
            {
                TempData["Result"] = "Cập nhật thành công!";
            }
            else
            {
                TempData["Result"] = "Cập nhật đơn thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}
