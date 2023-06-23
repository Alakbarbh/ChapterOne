using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IAutobiographyThreeService
    {
        Task<List<AutobiographyThree>> GetAllAsync();
        Task<AutobiographyThree> GetByIdAsync(int? id);
    }
}
