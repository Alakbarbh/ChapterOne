using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int? id);
    }
}
