using System.ComponentModel.DataAnnotations;

namespace ChapterOne.Areas.Admin.ViewModels
{
    public class BrandCreateVM
    {
        [Required(ErrorMessage = "Don't be empty")]
        public IFormFile Photo { get; set; }
    }
}
