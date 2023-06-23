using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(int? id);
    }
}
