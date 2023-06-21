using Microsoft.AspNetCore.Identity;

namespace ChapterOne.Models
{
    public class AppUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
