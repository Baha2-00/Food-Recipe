using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food_Recipe_Infra.Repos
{
    public class CuisineRepos : ICuisineRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public CuisineRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateCuisine(Cuisine createCuisineDto)
        {
            _RecipeDbContext.Cuisines.Add(createCuisineDto);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllCuisineDTO>> GetAllCuisine()
        {
            var query = from cuisine in _RecipeDbContext.Cuisines
                        where cuisine.IsDeleted == false
                        select new GetAllCuisineDTO
                        {
                            Id = cuisine.Id,
                            Title = cuisine.Title,
                            Description = cuisine.Description,
                            ImageUrl = $"https://localhost:44332/Images/{cuisine.ImageUrl}",
                            IsDeleted = cuisine.IsDeleted
                        };
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Cuisine> GetCuisineById(int id)
        {
            return await _RecipeDbContext.Cuisines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GetDeatilsCuisineDTO> GetDeatilsCuisine(int id)
        {
            var result = await _RecipeDbContext.Cuisines.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                GetDeatilsCuisineDTO response = new GetDeatilsCuisineDTO()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    ImageUrl= $"https://localhost:44332/Images/{result.ImageUrl}",
                    CreationDate = result.CreationDate,
                    IsDeleted = result.IsDeleted
                };
                return response;
            }
            throw new Exception("not found");
        }

        public async Task UpdateCuisine<U>(U input)
        {
                _RecipeDbContext.Update(input);
                await _RecipeDbContext.SaveChangesAsync();

        }
    }
}
