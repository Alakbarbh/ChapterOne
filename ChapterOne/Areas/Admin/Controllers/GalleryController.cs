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
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private IGalleryService _galleryService;
        public GalleryController(AppDbContext context,
                                IWebHostEnvironment env,
                                IGalleryService galleryService)

        {
            _context = context;
            _env = env;
            _galleryService = galleryService;
        }
        public async Task<IActionResult> Index()
        {
            List<Gallery> galleries = await _context.Galleries.ToListAsync();
            return View(galleries);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            Gallery gallery = await _galleryService.GetByIdAsync(id);
            if (gallery is null) return NotFound();
            return View(gallery);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryCreateVM gallery)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }


                if (!gallery.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image");
                    return View();
                }


                if (!gallery.Photo.CheckFileSize(200))
                {
                    ModelState.AddModelError("Photo", "Image size must be max 200kb");
                    return View();
                }



                string fileName = Guid.NewGuid().ToString() + "_" + gallery.Photo.FileName;


                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/home", fileName);

                await FileHelper.SaveFileAsync(path, gallery.Photo);

                Gallery newGallery = new()
                {
                    Image = fileName,
                };


                await _context.Galleries.AddAsync(newGallery);



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
                Gallery dbGallery = await _galleryService.GetByIdAsync(id);
                if (dbGallery is null) return NotFound();

                string path = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/home", dbGallery.Image);
                FileHelper.DeleteFile(path);

                _context.Galleries.Remove(dbGallery);
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
            Gallery dbGallery = await _galleryService.GetByIdAsync(id);
            if (dbGallery is null) return NotFound();

            GalleryUpdateVM model = new()
            {
                Image = dbGallery.Image,
            };

            return View(model);

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, GalleryUpdateVM galleryUpdate)
        {
            try
            {

                if (id == null) return BadRequest();

                Gallery dbGallery = await _galleryService.GetByIdAsync(id);

                if (dbGallery is null) return NotFound();

                GalleryUpdateVM model = new()
                {
                    Image = dbGallery.Image,
                };


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (galleryUpdate.Photo != null)
                {
                    if (!galleryUpdate.Photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photo", "Please choose correct image type");
                        return View(model);
                    }

                    if (!galleryUpdate.Photo.CheckFileSize(200))
                    {
                        ModelState.AddModelError("Photo", "Image size must be max 200kb");
                        return View(model);
                    }


                    string dbPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/home", galleryUpdate.Image);

                    FileHelper.DeleteFile(dbPath);


                    string fileName = Guid.NewGuid().ToString() + "_" + galleryUpdate.Photo.FileName;

                    string newPath = FileHelper.GetFilePath(_env.WebRootPath, "assets/images/home", fileName);

                    await FileHelper.SaveFileAsync(newPath, galleryUpdate.Photo);

                    galleryUpdate.Image = fileName;
                }
                else
                {
                    Gallery gallery = new()
                    {
                        Image = dbGallery.Image
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
