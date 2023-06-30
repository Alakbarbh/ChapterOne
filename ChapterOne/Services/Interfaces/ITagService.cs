using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllAsync();
        Task<Tag> GetByIdAsync(int? id);
    }
}
