using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;
        public TeamService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Team>> GetAllAsync() => await _context.Teams
                                                                     .Include(t => t.Position)
                                                                     .ToListAsync();
        public async Task<Team> GetFullDataByIdAsync(int? id) => await _context.Teams
                                                                                .Include(t => t.Position)
                                                                                .FirstOrDefaultAsync(m => m.Id == id);
    }
}
