using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;
        public TagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int? id)
        {
            return await _context.Tags.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
