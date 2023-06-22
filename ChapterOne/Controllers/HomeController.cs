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
        private readonly IourService _ourService;

        public HomeController(AppDbContext context,
                              ISliderService sliderService,
                              IourService ourService)
        {
            _context = context;
            _sliderService = sliderService;
            _ourService = ourService;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAll();
            List<Our> ours = await _ourService.GetAllAsync();

            HomeVM model = new()
            {
                Sliders = sliders,
                Ours = ours,
            };

            return View(model);
        }
    }
}