using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogs();
        Task<List<Blog>> GetPaginateDatas(int page, int take);
        Task<int> GetCountAsync();
        Task<Blog> GetById(int? id);
        Task<IEnumerable<Compiler>> GetCompilersAsync();
    }
}
