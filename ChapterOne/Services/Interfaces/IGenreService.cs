using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int? id);
    }
}
