using ChapterOne.Areas.Admin.ViewModels;
using ChapterOne.Data;
using ChapterOne.Helpers;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using ChapterOne.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using ProductDetailVM = ChapterOne.ViewModels.ProductDetailVM;

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


        public async Task<IActionResult> Index(int page = 1, int take = 5, int? cateId = null)
        {
            List<Product> paginateProduct = await _productService.GetPaginateDatas(page, take, cateId);
            int pageCount = await GetPageCountAsync(take);
            Paginate<Product> paginateDatas = new(paginateProduct, page, pageCount);

            List<Genre> genres = await _genreService.GetAllAsync();
            List<Product> newProducts = await _productService.GetNewProducts();
            List<Product> products = await _productService.GetAll();
            List<Tag> tags = await _tagService.GetAllAsync();
            List<Author> authors = await _authorService.GetAllAsync();
            Dictionary<string, string> headerBackground = _context.HeaderBackgrounds.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);

            ShopVM model = new()
            {
                Genres = genres,
                NewProduct = newProducts,
                Products = products,
                PaginateProduct = paginateDatas,
                Tags = tags,
                Authors = authors,
                HeaderBackgrounds = headerBackground,
            };

            return View(model);
        }


        private async Task<int> GetPageCountAsync(int take)
        {
            var productCount = await _productService.GetCountAsync();
            return (int)Math.Ceiling((decimal)productCount / take);
        }


        public async Task<IActionResult> GetAllProduct(int? id)
        {
            List<Product> products = await _productService.GetAll();

            return PartialView("_ProductsPartial", products);
        }


        public async Task<IActionResult> GetProductByAuthor(int? id)
        {
            List<Product> products = await _context.ProductAuthors.Include(m => m.Author).Include(m => m.Product).Where(m => m.AuthorId == id).Select(m => m.Product).ToListAsync();

            return PartialView("_ProductsPartial", products);
        }


        public async Task<IActionResult> GetProductByGenre(int? id)
        {
            List<Product> products = await _context.ProductGenres.Include(m => m.Product).ThenInclude(m => m.ProductGenres).Where(m => m.GenreId == id).Select(m => m.Product).ToListAsync();

            return PartialView("_ProductsPartial", products);
        }


        public async Task<IActionResult> GetProductsByTag(int? id)
        {
            List<Product> products = await _context.ProductTags.Where(m => m.Tag.Id == id).Select(m => m.Product).ToListAsync();

            return PartialView("_ProductsPartial", products);
        }


        public async Task<IActionResult> GetProductFilteredByPrice(string icon)
        {
            List<Product> products = await _context.Products.OrderByDescending(m => m.Price).ToListAsync();

            return PartialView("_ProductsPartial", products);
        }


        public async Task<IActionResult> MainSearch(string searchText)
        {
            var products = await _context.Products
                                .Include(m => m.ProductGenres)?
                                .OrderByDescending(m => m.Id)
                                .Where(m => !m.SoftDelete && m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim()))
                                .ToListAsync();

            return View(products);
        }


        public async Task<IActionResult> Search(string searchText)
        {
            List<Product> products = await _context.Products.Include(m => m.Image)
                                            .Include(m => m.ProductGenres)
                                            .Include(m => m.ProductAuthors)
                                            .Include(m => m.ProductTags)
                                            .Where(m => m.Name.ToLower().Contains(searchText.ToLower()))
                                            .Take(5)
                                            .ToListAsync();
            return PartialView("_SearchPartial", products);
        }


        public async Task<IActionResult> ProductDetail(int? id)
        {
            Product productDt = await _productService.GettFullDataById((int)id);
            Dictionary<string, string> headerBackgrounds = _context.HeaderBackgrounds.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);
            List<Genre> genres = await _genreService.GetAllAsync();
            List<Product> releatedProducts = new();

            List<ProductComment> productComments = await _context.ProductComments.Include(m => m.AppUser).Where(m => m.ProductId == id).ToListAsync();
            CommentVM commentVM = new CommentVM();

            foreach (var genre in genres)
            {
                Product releatedProduct = await _context.ProductGenres.Include(m => m.Product).Where(m => m.Genre.Id == genre.Id).Select(m => m.Product).FirstAsync();
                releatedProducts.Add(releatedProduct);
            }

            ProductDetailVM model = new()
            {
                ProductDt = productDt,
                HeaderBackgrounds = headerBackgrounds,
                RelatedProducts = releatedProducts,
                CommentVM = commentVM,
                ProductComments = productComments
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> PostComment(ProductDetailVM productDetailVM, string userId, int productId)
        {
            if (productDetailVM.CommentVM.Message == null)
            {
                ModelState.AddModelError("Message", "Don't empty");
                return RedirectToAction(nameof(ProductDetail), new { id = productId });
            }

            ProductComment productComment = new()
            {
                FullName = productDetailVM.CommentVM?.FullName,
                Email = productDetailVM.CommentVM?.Email,
                Subject = productDetailVM.CommentVM?.Subject,
                Message = productDetailVM.CommentVM?.Message,
                AppUserId = userId,
                ProductId = productId
            };

            await _context.ProductComments.AddAsync(productComment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ProductDetail), new { id = productId });

        }


    }
}
