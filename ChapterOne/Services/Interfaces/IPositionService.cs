using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IPositionService
    {
        Task<List<Position>> GetAllAsync();
        Task<Position> GetByIdAsync(int? id);
    }
}
