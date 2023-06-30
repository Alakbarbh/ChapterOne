using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int? id)
        {
            return await _context.Authors.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
