using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.Ingredient;
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
    public class IngredientRepos : IIngredientRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public IngredientRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateIngredients(Ingredients createIngredients)
        {
            _RecipeDbContext.Ingredient.Add(createIngredients);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetALLIngredients>> GetAllIngredients()
        {
            var query = from ing in _RecipeDbContext.Ingredient
                        select new GetALLIngredients
                        {
                            Id = ing.Id,
                            Name = ing.Name,
                            Description = ing.Description,
                            Title = ing.Title,
                            Image=ing.Image
                        };
            return await query.ToListAsync();
        }

        public async Task<Ingredients> GetIngredientsByID(int id)
        {
            return await _RecipeDbContext.Ingredient.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GetIngredientDetails> GetIngredientsDetails(int id)
        {
            var result = await _RecipeDbContext.Ingredient.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                GetIngredientDetails response = new GetIngredientDetails()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    Title= result.Title,
                    Image=result.Image,
                    CreationDate = result.CreationDate,
                    IsDeleted = result.IsDeleted
                };
                return response;
            }
            throw new Exception("not found");
        }

        public async Task UpdateOrDeleteIngredients(UpdateIngredients updateIngredients)
        {
            var query = await _RecipeDbContext.Ingredient.FindAsync(updateIngredients.Id);

            if (query != null)
            {
                query.Name = updateIngredients.Name;
                query.Description = updateIngredients.Description;
                query.Image = updateIngredients.Image;
                query.Title = updateIngredients.Title;
                query.IsDeleted = updateIngredients.IsDeleted;
                _RecipeDbContext.Update(query);
                await _RecipeDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }
    }
}
