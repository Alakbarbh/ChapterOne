using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class WrapperService : IWrapperService
    {
        private readonly AppDbContext _context;
        public WrapperService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Wrapper>> GetAllAsync()
        {
            return await _context.Wrappers.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Wrapper> GetByIdAsync(int? id)
        {
            return await _context.Wrappers.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
