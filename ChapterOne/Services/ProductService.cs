using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll() => await _context.Products
                                                                                       .Include(m => m.ProductTags)
                                                                                       .ThenInclude(m => m.Tag)
                                                                                       .Include(m => m.ProductComments)
                                                                                       .Include(m => m.ProductGenres)
                                                                                       .Include(m => m.ProductAuthors)
                                                                                       .ToListAsync();

        public async Task<Product> GettFullDataById(int id)
        {
            var a = await _context.Products
                                                                .Include(m => m.ProductTags)
                                                                .ThenInclude(m => m.Tag)
                                                                .Include(m=>m.ProductAuthors)
                                                                .ThenInclude(m => m.Author)
                                                                .Include(m => m.ProductComments)
                                                                .Include(m => m.ProductGenres)
                                                                .ThenInclude(m => m.Genre)
                                                                .FirstOrDefaultAsync(m => m.Id == id);
            return a;
        }


        public async Task<Product> GetById(int id) => await _context.Products.FindAsync(id);
        public async Task<int> GetCountAsync() => await _context.Products.CountAsync();

        public async Task<List<Product>> GetFeaturedProducts() => await _context.Products.Where(m => !m.SoftDelete).OrderByDescending(m => m.Rate).ToListAsync();
        public async Task<List<Product>> GetBestsellerProducts() => await _context.Products.Where(m => !m.SoftDelete).OrderByDescending(m => m.SaleCount).ToListAsync();
        public async Task<List<Product>> GetLatestProducts() => await _context.Products.Where(m => !m.SoftDelete).OrderByDescending(m => m.CreateDate).ToListAsync();
        public async Task<List<Product>> GetNewProducts() => await _context.Products.Where(m => !m.SoftDelete).OrderByDescending(m => m.CreateDate).Take(4).ToListAsync();
        public async Task<Product> GetFullDataById(int id) => await _context.Products.Include(m => m.ProductGenres).FirstOrDefaultAsync(m => m.Id == id);


        public async Task<List<Product>> GetPaginateDatas(int page, int take, int? cateId)
        {
            List<Product> products = null;

            if (cateId == null)
            {
                products = await _context.Products.

            Include(m => m.ProductGenres)?.
            Include(m => m.ProductTags).
            Include(m => m.ProductAuthors).
            Include(m => m.ProductComments).Where(m => !m.SoftDelete).
            Skip((page * take) - take).
            Take(take).ToListAsync();
            }
            else
            {
                products = await _context.ProductGenres.Include(m => m.Product).Where(m => m.Genre.Id == cateId).Select(m => m.Product).Where(m => !m.SoftDelete).
                Skip((page * take) - take).
                Take(take).ToListAsync();
            }

            return products;


        }
    }
}
