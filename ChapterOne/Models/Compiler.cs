using System.Reflection.Metadata;

namespace ChapterOne.Models
{
    public class Compiler : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Blog> BLogs { get; set; }
    }
}
