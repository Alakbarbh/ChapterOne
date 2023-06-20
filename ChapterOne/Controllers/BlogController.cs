using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
