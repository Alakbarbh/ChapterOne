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

        public ContactController(AppDbContext context,
                               IWrapperService wrapperService,
                               IStoreService storeService)
        {
            _context = context;
            _wrapperService = wrapperService;
            _storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            List<Store> stores = await _storeService.GetAllAsync();


            ContactVM model = new()
            {
                Stores = stores,
            };

            return View(model);
        }
    }
}
