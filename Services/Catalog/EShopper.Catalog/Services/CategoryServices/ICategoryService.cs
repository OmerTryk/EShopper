﻿using E_Shopper.Catalog.Dtos.CatagoryDtos;
using E_Shopper.Catalog.Dtos.CategoryDtos;

namespace E_Shopper.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); 
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); 
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); 
        Task DeleteCategoryAsync(string id); 
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id); 
    }
}
