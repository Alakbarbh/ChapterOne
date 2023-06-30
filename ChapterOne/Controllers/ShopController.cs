using ChapterOne.Data;
using ChapterOne.Helpers;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using ChapterOne.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ChapterOne.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IGenreService _genreService;
        private readonly IProductService _productService;
        private readonly ITagService _tagService;
        private readonly IAuthorService _authorService;

        public ShopController(AppDbContext context,
                              IGenreService genreService,
                              IProductService productService,
                              IAuthorService authorService,
                              ITagService tagService)

        {
            _context = context;
            _genreService = genreService;
            _productService = productService;
            _authorService = authorService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(/*int page = 1, int take = 5, int? cateId = null*/)
        {
            //List<Product> paginateProduct = await _productService.GetPaginateDatas(page, take, cateId);
            //int pageCount = await GetPageCountAsync(take);
            //Paginate<Product> paginateDatas = new(paginateProduct, page, pageCount);

            List<Genre> genres = await _genreService.GetAllAsync();
            List<Product> newProducts = await _productService.GetNewProducts();
            List<Product> products = await _productService.GetAll();
            List<Tag> tags = await _tagService.GetAllAsync();
            List<Author> authors = await _authorService.GetAllAsync();

            ShopVM model = new()
            {
                Genres = genres,
                NewProduct = newProducts,
                Products = products,
                //PaginateProduct = paginateDatas,
                Tags = tags,
                Authors = authors,
            };

            return View(model);
        }

        //private async Task<int> GetPageCountAsync(int take)
        //{
        //    var productCount = await _productService.GetCountAsync();
        //    return (int)Math.Ceiling((decimal)productCount / take);
        //}
    }
}
