using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
