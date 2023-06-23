using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IWrapperService
    {
        Task<List<Wrapper>> GetAllAsync();
        Task<Wrapper> GetByIdAsync(int? id);
    }
}
