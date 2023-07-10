﻿using ChapterOne.Models;

namespace ChapterOne.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
        Task<int> GetCountAsync();
        Task<List<Product>> GetFeaturedProducts();
        Task<List<Product>> GetBestsellerProducts();
        Task<List<Product>> GetLatestProducts();
        Task<List<Product>> GetNewProducts();
        Task<Product> GetFullDataById(int id);
        Task<Product> GettFullDataById(int id);
        Task<List<Product>> GetPaginateDatas(int page, int take, int? cateId);
        Task<List<ProductComment>> GetComments();
        Task<ProductComment> GetCommentByIdWithProduct(int? id);
        Task<ProductComment> GetCommentById(int? id);
        //Task<List<Product>> GetActionGenresProducts();
    }
}
