using ChapterOne.Models;

namespace ChapterOne.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Our> Ours { get; set; }
        public List<AutobiographyOne> AutobiographyOnes { get; set; }
        public List<AutobiographyTwo> AutobiographyTwos { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Gallery> Galleries { get; set; }
        public List<Team> Teams { get; set; }
        public List<Position> Positions { get; set; }
        public Dictionary<string, string> HeaderBackgrounds { get; set; }
    }
}
