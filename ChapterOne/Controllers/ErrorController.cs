using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
