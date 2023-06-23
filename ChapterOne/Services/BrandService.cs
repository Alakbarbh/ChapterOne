﻿using ChapterOne.Data;
using ChapterOne.Models;
using ChapterOne.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChapterOne.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _context;
        public BrandService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Brand> GetByIdAsync(int? id)
        {
            return await _context.Brands.Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
