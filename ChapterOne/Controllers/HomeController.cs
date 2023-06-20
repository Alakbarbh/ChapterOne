using ChapterOne.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChapterOne.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}