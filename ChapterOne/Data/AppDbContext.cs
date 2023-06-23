using ChapterOne.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Our> Ours { get; set; }
        public DbSet<AutobiographyOne> AutobiographyOnes { get; set; }
        public DbSet<AutobiographyTwo> AutobiographyTwos { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Wrapper> Wrappers { get; set; }
        public DbSet<AutobiographyThree> AutobiographyThrees { get; set; }
        public DbSet<AutobiographyFour> AutobiographyFours { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
