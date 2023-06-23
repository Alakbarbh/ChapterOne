using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IAutobiographyFourService
    {
        Task<List<AutobiographyFour>> GetAllAsync();
        Task<AutobiographyFour> GetByIdAsync(int? id);
    }
}
