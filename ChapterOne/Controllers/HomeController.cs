using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using ChapterOne.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ChapterOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;

        public HomeController(AppDbContext context,
                              ISliderService sliderService)
        {
            _context = context;
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAll();

            HomeVM model = new()
            {
                Sliders = sliders,
            };

            return View(model);
        }
    }
}