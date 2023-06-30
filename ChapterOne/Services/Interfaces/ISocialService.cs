using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface ISocialService
    {
        Task<List<Social>> GetSocialsAsync();
        Task<Social> GetByIdAsync(int? id);
    }
}
