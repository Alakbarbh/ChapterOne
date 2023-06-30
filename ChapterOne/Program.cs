using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services;
using ChapterOne.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSession();


builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IourService, OurService>();
builder.Services.AddScoped<IAutobiographyOneService, AutobiographyOneService>();
builder.Services.AddScoped<IAutobiographyTwoService, AutobiographyTwoService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IWrapperService, WrapperService>();
builder.Services.AddScoped<IAutobiographyThreeService, AutobiographyThreeService>();
builder.Services.AddScoped<IAutobiographyFourService, AutobiographyFourService>();
builder.Services.AddScoped<IPromoService, PromoService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IBrandTwoService, BrandTwoService>();
builder.Services.AddScoped<ILayoutService, LayoutService>();
builder.Services.AddScoped<ISocialService, SocialService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
