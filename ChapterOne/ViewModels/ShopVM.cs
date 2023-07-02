using ChapterOne.Helpers;
using ChapterOne.Models;
using System.Drawing;

namespace ChapterOne.ViewModels
{
    public class ShopVM
    {
        public List<Genre> Genres { get; set; }
        public List<Product> NewProduct { get; set; }
        public List<Product> Products { get; set; }
        public List<Author> Authors { get; set; }
        public Paginate<Product> PaginateProduct { get; set; }
        public List<Tag> Tags { get; set; }
        public Dictionary<string, string> HeaderBackgrounds { get; set; }
    }
}
