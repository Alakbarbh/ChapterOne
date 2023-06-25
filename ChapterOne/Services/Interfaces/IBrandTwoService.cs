using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IBrandTwoService
    {
        Task<List<BrandTwo>> GetAllAsync();
        Task<BrandTwo> GetByIdAsync(int? id);
    }
}
