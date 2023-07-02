using ChapterOne.Models;

namespace ChapterOne.ViewModels
{
    public class ContactVM
    {
        public List<Store> Stores { get; set; }
        public List<BrandTwo> BrandTwos { get; set; }
        public Dictionary<string, string> HeaderBackgrounds { get; set; }
    }
}
