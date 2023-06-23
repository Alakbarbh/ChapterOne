using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly AppDbContext _context;
        public GalleryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            return await _context.Galleries.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Gallery> GetByIdAsync(int? id)
        {
            return await _context.Galleries.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
