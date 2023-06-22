using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IAutobiographyOneService
    {
        Task<List<AutobiographyOne>> GetAllAsync();
        Task<AutobiographyOne> GetByIdAsync(int? id);
    }
}
