using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogs() => await _context.Blogs.
                                                 Where(m => !m.SoftDelete).
                                                 Include(m => m.Compiler).
                                                 Include(m => m.BlogComments).
                                                 ToListAsync();
        public async Task<int> GetCountAsync() => await _context.Products.CountAsync();
        public async Task<List<Blog>> GetPaginateDatas(int page, int take) => await _context.Blogs.
            Where(m => !m.SoftDelete).
            Include(m => m.Compiler).
            Include(m => m.BlogComments).
            Skip((page * take) - take).
            Take(take).ToListAsync();
        public async Task<Blog> GetById(int? id)
        {
            return await _context.Blogs.Where(m => !m.SoftDelete).
                                        Include(m => m.Compiler).
                                        Include(m => m.BlogComments).
                                        FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<IEnumerable<Compiler>> GetCompilersAsync() => await _context.Compilers.ToListAsync();
        public async Task<List<BlogComment>> GetComments()
        {
            return await _context.BlogComments.Include(b => b.Blog).ToListAsync();
        }
        public async Task<BlogComment> GetCommentByIdWithBlog(int? id)
        {
            return await _context.BlogComments.Include(b => b.Blog).FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<BlogComment> GetCommentById(int? id)
        {
            return await _context.BlogComments.FindAsync(id);
        }
    }
}
