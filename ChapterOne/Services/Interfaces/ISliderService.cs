using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAll();
        Task<Slider> GetById(int? id);
    }
}
