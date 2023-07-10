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
                                                                        .ThenInclude(m => m.Genre)
                                                                        .Include(m => m.ProductAuthors)
                                                                        .ThenInclude(m => m.Author)
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

        //public async Task<List<Product>> GetActionGenresProducts() => await _context.Products.Include(m=>m.ProductGenres).ThenInclude(m=>m.Product).Where(m => m.ProductGenres.FirstOrDefault().GenreId == 2).Select(m=>m.ProductGenres.Select(m=>m.Product).ToList());

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
        public async Task<List<ProductComment>> GetComments()
        {
            return await _context.ProductComments.Include(p => p.Product).ToListAsync();
        }
        public async Task<ProductComment> GetCommentByIdWithProduct(int? id)
        {
            return await _context.ProductComments.Include(p => p.Product).FirstOrDefaultAsync(pc => pc.Id == id);
        }
        public async Task<ProductComment> GetCommentById(int? id)
        {
            return await _context.ProductComments.FirstOrDefaultAsync(pc => pc.Id == id);
        }
    }
}
