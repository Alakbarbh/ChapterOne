using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class BrandTwoService : IBrandTwoService
    {
        private readonly AppDbContext _context;
        public BrandTwoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BrandTwo>> GetAllAsync()
        {
            return await _context.BrandTwos.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<BrandTwo> GetByIdAsync(int? id)
        {
            return await _context.BrandTwos.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
