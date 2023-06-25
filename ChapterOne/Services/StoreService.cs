using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class StoreService : IStoreService
    {
        private readonly AppDbContext _context;
        public StoreService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _context.Stores.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Store> GetByIdAsync(int? id)
        {
            return await _context.Stores.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
