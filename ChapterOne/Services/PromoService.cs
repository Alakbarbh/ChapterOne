using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class PromoService : IPromoService
    {
        private readonly AppDbContext _context;
        public PromoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Promo>> GetAllAsync()
        {
            return await _context.Promos.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Promo> GetByIdAsync(int? id)
        {
            return await _context.Promos.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
