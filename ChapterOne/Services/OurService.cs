using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class OurService : IourService
    {
        private readonly AppDbContext _context;
        public OurService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Our>> GetAllAsync()
        {
            return await _context.Ours.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Our> GetByIdAsync(int? id)
        {
            return await _context.Ours.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
