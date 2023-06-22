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
        private readonly IAutobiographyOneService _autobiographyOneService;
        private readonly IAutobiographyTwoService _autobiographyTwoService;

        public HomeController(AppDbContext context,
                              ISliderService sliderService,
                              IourService ourService,
                              IAutobiographyOneService autobiographyOneService,
                              IAutobiographyTwoService autobiographyTwoService)
        {
            _context = context;
            _sliderService = sliderService;
            _ourService = ourService;
            _autobiographyOneService = autobiographyOneService;
            _autobiographyTwoService = autobiographyTwoService;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAll();
            List<Our> ours = await _ourService.GetAllAsync();
            List<AutobiographyOne> autobiographyOnes = await _autobiographyOneService.GetAllAsync();
            List<AutobiographyTwo> autobiographyTwos = await _autobiographyTwoService.GetAllAsync();

            HomeVM model = new()
            {
                Sliders = sliders,
                Ours = ours,
                AutobiographyOnes = autobiographyOnes,
                AutobiographyTwos = autobiographyTwos,
            };

            return View(model);
        }
    }
}