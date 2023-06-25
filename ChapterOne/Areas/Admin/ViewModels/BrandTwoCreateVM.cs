using System.ComponentModel.DataAnnotations;

namespace ChapterOne.Areas.Admin.ViewModels
{
    public class BrandTwoCreateVM
    {
        [Required(ErrorMessage = "Don't be empty")]
        public IFormFile Photo { get; set; }
    }
}
