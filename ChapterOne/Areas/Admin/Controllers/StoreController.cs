using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services;
using ChapterOne.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IStoreService _storeService;
        public StoreController(AppDbContext context,
                                IWebHostEnvironment env,
                                IStoreService storeService)
        {
            _context = context;
            _env = env;
            _storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            List<Store> stores = await _context.Stores.ToListAsync();
            return View(stores);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            Store store = await _storeService.GetByIdAsync(id);
            if (store is null) return NotFound();
            return View(store);
        }
    }
}
