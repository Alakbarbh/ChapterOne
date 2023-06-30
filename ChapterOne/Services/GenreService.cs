using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class GenreService : IGenreService
    {
        private readonly AppDbContext _context;
        public GenreService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int? id)
        {
            return await _context.Genres.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
