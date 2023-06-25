using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IPromoService
    {
        Task<List<Promo>> GetAllAsync();
        Task<Promo> GetByIdAsync(int? id);
    }
}
