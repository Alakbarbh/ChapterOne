using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChapterOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ITagService _tagService;
        public TagController(AppDbContext context,
                                IWebHostEnvironment env,
                                ITagService tagService)
        {
            _context = context;
            _env = env;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _tagService.GetAllAsync();
            return View(tags);
        }
    }
}
