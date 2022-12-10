using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.WebSite.Interface;
using System.Linq;

namespace SupportRegister.WebSite.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "student")]
    public class FeedbackController : Controller
    {
        private readonly IFeedback _feedback;
        public FeedbackController()
        {
            _feedback = RestService.For<IFeedback>("https://localhost:44363");
        }
        public IActionResult Index()
        {
            if (TempData["Result"] != null)
            {
                ViewBag.SuccessMsg = TempData["Result"];
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(string title_mail, string content_mail)
        {
            var userId = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var student = _feedback.Create(title_mail, content_mail, userId).GetAwaiter().GetResult();
            if (student >= 1)
            {
                TempData["Result"] = "Viết phản hồi thành công!";
            }
            else
            {
                TempData["Result"] = "Viết phản hồi thất bại!";
            }
            return RedirectToAction("Index");
        }
    }
}
