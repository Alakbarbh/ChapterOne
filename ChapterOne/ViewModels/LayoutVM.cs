namespace ChapterOne.ViewModels
{
    public class LayoutVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public int BasketCount { get; set; }
        public IEnumerable<CartVM> CartVMs { get; set; }
    }
}
