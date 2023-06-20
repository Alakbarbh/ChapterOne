using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
