using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.DTOs.Ingredient;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Food_Recipe_Infra.Repos
{
    public class DishIngredientsRepos : IDishIngredientsRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public DishIngredientsRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateDishIngredient(DishIngredient dt)
        {
            _RecipeDbContext.DishIngredients.Add(dt);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllDishIngredients>> GetAllDishIngredients()
        {
            var query = from DiIng in _RecipeDbContext.DishIngredients
                        select new GetAllDishIngredients
                        {
                           ID=DiIng.Id,
                           DishId= (int)DiIng.DishId,
                           IngredientId=DiIng.IngredientId,
                           Quantity=DiIng.Quantity,
                           quantityUnit= DiIng.quantityUnit.ToString()
                        };
            return await query.ToListAsync();
        }

        public async Task<DishIngredient> GetDishIngredientsByID(int id)
        {
            return await _RecipeDbContext.DishIngredients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DetailsDishIngredients> GetDishIngredientsDetails(int id)
        {
            var res= await _RecipeDbContext.DishIngredients.FirstOrDefaultAsync(x=>x.Id==id);
            if (res != null)
            {
                var dish = await _RecipeDbContext.Dishs.FirstOrDefaultAsync(x => x.Id == res.DishId);
                var ingred = await _RecipeDbContext.Ingredient.FirstOrDefaultAsync(x => x.Id == res.IngredientId);
                DetailsDishIngredients details = new DetailsDishIngredients()
                {
                    Id= res.Id,
                    DishName = dish == null ? "No Dish" : dish.Name,
                    IngredientName= ingred == null ? "No Ingredients" : ingred.Name,
                    Quantity= res.Quantity,
                    quantityUnit= res.quantityUnit.ToString(),
                    CreationDate= res.CreationDate,
                    IsDeleted= res.IsDeleted
                };
                return details;
            }
            throw new Exception("not found");
        }

        public async Task UpdateOrDeleteDishIngredient<T>(T dt)
        {
            _RecipeDbContext.Update(dt);
            await _RecipeDbContext.SaveChangesAsync();
        }
    }
}
