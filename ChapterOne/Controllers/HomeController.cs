﻿using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services;
using ChapterOne.Services.Interfaces;
using ChapterOne.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ChapterOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISliderService _sliderService;
        private readonly IourService _ourService;
        private readonly IAutobiographyOneService _autobiographyOneService;
        private readonly IAutobiographyTwoService _autobiographyTwoService;
        private readonly IBrandService _brandService;
        private readonly IGalleryService _galleryService;
        private readonly ITeamService _teamService;
        private readonly IProductService _produtcService;
        private readonly IGenreService _genreService;

        public HomeController(AppDbContext context,
                              ISliderService sliderService,
                              IourService ourService,
                              IAutobiographyOneService autobiographyOneService,
                              IAutobiographyTwoService autobiographyTwoService,
                              IBrandService brandService,
                              IGalleryService galleryService,
                              ITeamService teamService,
                              IProductService productService,
                              IGenreService genreService)
        {
            _context = context;
            _sliderService = sliderService;
            _ourService = ourService;
            _autobiographyOneService = autobiographyOneService;
            _autobiographyTwoService = autobiographyTwoService;
            _brandService = brandService;
            _galleryService = galleryService;
            _teamService = teamService;
            _produtcService = productService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAll();
            List<Our> ours = await _ourService.GetAllAsync();
            List<AutobiographyOne> autobiographyOnes = await _autobiographyOneService.GetAllAsync();
            List<AutobiographyTwo> autobiographyTwos = await _autobiographyTwoService.GetAllAsync();
            List<Brand> brands = await _brandService.GetAllAsync();
            List<Gallery> galleries = await _galleryService.GetAllAsync();
            List<Team> teams = await _teamService.GetAllAsync();
            List<Product> products = await _produtcService.GetAll();
            List<Genre> genres = await _genreService.GetAllAsync();
            Dictionary<string, string> headerBackground = _context.HeaderBackgrounds.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);
            HomeVM model = new()
            {
                Sliders = sliders,
                Ours = ours,
                AutobiographyOnes = autobiographyOnes,
                AutobiographyTwos = autobiographyTwos,
                Brands = brands,
                Galleries = galleries,
                Teams = teams,
                HeaderBackgrounds = headerBackground,
                Products = products,
                Genres = genres
            };

            return View(model);
        }
    }
}