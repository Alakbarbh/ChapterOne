﻿using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
