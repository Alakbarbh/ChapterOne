using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAllAsync();
        Task<Store> GetByIdAsync(int? id);
    }
}
