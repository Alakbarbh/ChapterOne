using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class SocialService : ISocialService
    {
        private readonly AppDbContext _context;
        public SocialService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Social>> GetSocialsAsync()
        {
            return await _context.Socials.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Social> GetByIdAsync(int? id)
        {
            return await _context.Socials.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
