using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
