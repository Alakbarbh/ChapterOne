using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AutobiographyOneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
