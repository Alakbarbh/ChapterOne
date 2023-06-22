using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IourService
    {
        Task<List<Our>> GetAllAsync();
        Task<Our> GetByIdAsync(int? id);
    }
}
