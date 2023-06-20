using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
