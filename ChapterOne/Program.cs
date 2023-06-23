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
