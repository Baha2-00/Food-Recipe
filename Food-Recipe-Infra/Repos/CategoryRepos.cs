﻿using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class CategoryRepos : ICategoryRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public CategoryRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }

        public Task CreateCategory(Category createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllCategoryDTO>> GetAllCategory()
        {
            var query = from cate in _RecipeDbContext.Categories
                        select new GetAllCategoryDTO
                        {
                            Id = cate.Id,
                            Title = cate.Title,
                            ImageUrl=cate.ImageUrl,
                            CreationDate = cate.CreationDate
                        };
            return await query.ToListAsync();
        }

        public async Task<GetDetailsCategoryDTO> GetCategoryDetails(int id)
        {
            var result= await _RecipeDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                GetDetailsCategoryDTO response = new GetDetailsCategoryDTO()
                {
                    Id= result.Id,
                    Title= result.Title,
                    Description= result.Description,
                    ImageUrl=result.ImageUrl,
                    CreationDate= result.CreationDate,
                    IsDeleted= result.IsDeleted,
                };
                return response;
            }
            throw new Exception("not found");
        }

        public Task UpdateOrDeleteCategory(UpdateCategoryDTO updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
