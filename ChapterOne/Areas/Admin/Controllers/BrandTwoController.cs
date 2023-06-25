using ChapterOne.Areas.Admin.ViewModels;
using ChapterOne.Data;
using ChapterOne.Helpers;
using ChapterOne.Models;
using ChapterOne.Services;
using ChapterOne.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandTwoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private IBrandTwoService _brandTwoService;
        public BrandTwoController(AppDbContext context,
                                IWebHostEnvironment env,
                                IBrandTwoService brandTwoService)

        {
            _context = context;
            _env = env;
            _brandTwoService = brandTwoService;
        }

        public async Task<IActionResult> Index()
        {
            List<BrandTwo> brandTwos = await _context.BrandTwos.ToListAsync();
            return View(brandTwos);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            BrandTwo brandTwo = await _brandTwoService.GetByIdAsync(id);
            if (brandTwo is null) return NotFound();
            return View(brandTwo);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandTwoCreateVM brand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }



                if (!brand.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View();
                }




                if (!brand.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 200kb");
                    return View();
                }



                string fileName = Guid.NewGuid().ToString() + "_" + brand.Photo.FileName;


                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/contact", fileName);

                await FileHelper.SaveFileAsync(path, brand.Photo);

                BrandTwo newBrandTwo = new()
                {
                    Image = fileName,
                };


                await _context.BrandTwos.AddAsync(newBrandTwo);



                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null) return BadRequest();
                BrandTwo dbBrandTwo = await _brandTwoService.GetByIdAsync(id);
                if (dbBrandTwo is null) return NotFound();

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/contact", dbBrandTwo.Image);
                FileHelper.DeleteFile(path);

                _context.BrandTwos.Remove(dbBrandTwo);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            BrandTwo dbBrandTwo = await _brandTwoService.GetByIdAsync(id);
            if (dbBrandTwo is null) return NotFound();

            BrandTwoUpdateVM model = new()
            {
                Image = dbBrandTwo.Image,
            };

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BrandTwoUpdateVM brandTwoUpdate)
        {
            try
            {

                if (id == null) return BadRequest();

                BrandTwo dbBrandTwo = await _brandTwoService.GetByIdAsync(id);

                if (dbBrandTwo is null) return NotFound();

                BrandTwoUpdateVM model = new()
                {
                    Image = dbBrandTwo.Image,
                };


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (brandTwoUpdate.Photo != null)
                {
                    if (!brandTwoUpdate.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View(model);
                    }

                    if (!brandTwoUpdate.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(model);
                    }


                    string dbPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/contact", dbBrandTwo.Image);

                    FileHelper.DeleteFile(dbPath);


                    string fileName = Guid.NewGuid().ToString() + "_" + brandTwoUpdate.Photo.FileName;

                    string newPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/contact", fileName);

                    await FileHelper.SaveFileAsync(newPath, brandTwoUpdate.Photo);

                    dbBrandTwo.Image = fileName;
                }
                else
                {
                    BrandTwo brandTwo = new()
                    {
                        Image = dbBrandTwo.Image
                    };
                }


                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                @ViewBag.error = ex.Message;
                return View();
            }
        }
    }
}
