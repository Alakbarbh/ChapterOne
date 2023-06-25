using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services;
using ChapterOne.Services.Interfaces;
using ChapterOne.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWrapperService _wrapperService;
        private readonly IAutobiographyThreeService _autobiographyThreeService;
        private readonly IAutobiographyFourService _autobiographyFourService;
        private readonly IPromoService _promoService;

        public AboutController(AppDbContext context,
                               IWrapperService wrapperService,
                               IAutobiographyThreeService autobiographyThreeService,
                               IAutobiographyFourService autobiographyFourService,
                               IPromoService promoService)
        {
            _context = context;
            _wrapperService = wrapperService;
            _autobiographyThreeService = autobiographyThreeService;
            _autobiographyFourService = autobiographyFourService;
            _promoService = promoService;
        }
        public async Task<IActionResult> Index()
        {
            List<Wrapper> wrappers = await _wrapperService.GetAllAsync();
            List<AutobiographyThree> autobiographyThrees = await _autobiographyThreeService.GetAllAsync();
            List<AutobiographyFour> autobiographyFours = await _autobiographyFourService.GetAllAsync();
            List<Promo> promos = await _promoService.GetAllAsync();


            AboutVM model = new()
            {
                Wrappers = wrappers,
                AutobiographyThrees = autobiographyThrees,
                AutobiographyFours = autobiographyFours,
                Promos = promos,
            };

            return View(model);
        }
    }
}
