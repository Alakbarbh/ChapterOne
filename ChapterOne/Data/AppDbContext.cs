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
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<BrandTwo> BrandTwos { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductAuthor> ProductAuthors { get; set; }
        public DbSet<ProductGenre> ProductGenres { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
