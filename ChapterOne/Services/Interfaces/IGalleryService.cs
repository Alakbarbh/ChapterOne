using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IGalleryService
    {
        Task<List<Gallery>> GetAllAsync();
        Task<Gallery> GetByIdAsync(int? id);
    }
}
