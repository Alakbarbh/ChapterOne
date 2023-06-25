using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services;
using ChapterOne.Services.Interfaces;
using ChapterOne.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWrapperService _wrapperService;
        private readonly IStoreService _storeService;
        private readonly IBrandTwoService _brandTwoService;

        public ContactController(AppDbContext context,
                               IWrapperService wrapperService,
                               IStoreService storeService,
                               IBrandTwoService brandTwoService)
        {
            _context = context;
            _wrapperService = wrapperService;
            _storeService = storeService;
            _brandTwoService = brandTwoService;
        }

        public async Task<IActionResult> Index()
        {
            List<Store> stores = await _storeService.GetAllAsync();
            List<BrandTwo> brandTwos = await _brandTwoService.GetAllAsync();


            ContactVM model = new()
            {
                Stores = stores,
                BrandTwos = brandTwos,
            };

            return View(model);
        }
    }
}
