using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllAsync();
        Task<Team> GetFullDataByIdAsync(int? id);
    }
}
