using ChapterOne.Areas.Admin.ViewModels;
using ChapterOne.Data;
using ChapterOne.Helpers;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace ChapterOne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IProductService _productService;
        private readonly IAuthorService _authorService;
        private readonly ITagService _tagService;
        private readonly IGenreService _genreService;
        public ProductController(AppDbContext context,
                                IWebHostEnvironment env,
                                IProductService productService,
                                IAuthorService authorService,
                                ITagService tagService,
                                IGenreService genreService)
        {
            _context = context;
            _env = env;
            _productService = productService;
            _authorService = authorService;
            _tagService = tagService;
            _genreService = genreService;
        }


        public async Task<IActionResult> Index(/*int page = 1, int take = 5, int? cateId = null*/)
        {
            List<Product> products = await _productService.GetPaginateDatas(page, take, cateId);
            List<ProductListVM> mappedDatas = GetMappedDatas(products);
            int pageCount = await GetPageCountAsync(take);
            Paginate<ProductListVM> paginatedDatas = new(mappedDatas, page, pageCount);
            ViewBag.take = take;
            return View(paginatedDatas);
        }


        private async Task<SelectList> GetGenreAsync()
        {
            IEnumerable<Genre> categories = await _genreService.GetAllAsync();
            return new SelectList(categories, "Id", "Name");
        }


        private async Task<SelectList> GetAuthorAsync()
        {
            IEnumerable<Author> authors = await _authorService.GetAllAsync();
            return new SelectList(authors, "Id", "Name");
        }


        private async Task<SelectList> GetTagAsync()
        {
            IEnumerable<Tag> tags = await _tagService.GetAllAsync();
            return new SelectList(tags, "Id", "Name");
        }


        private async Task<int> GetPageCountAsync(int take)
        {
            var productCount = await _productService.GetCountAsync();
            return (int)Math.Ceiling((decimal)productCount / take);
        }


        private List<ProductListVM> GetMappedDatas(List<Product> products)
        {
            List<ProductListVM> mappedDatas = new();

            foreach (var product in products)
            {
                ProductListVM productVM = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    SKU = product.SKU
                };

                mappedDatas.Add(productVM);

            }

            return mappedDatas;
        }
    }
}
