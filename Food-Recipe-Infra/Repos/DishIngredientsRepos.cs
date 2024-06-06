using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.DishIngredients;
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

        public async Task<DetailsDishIngredients> GetDishIngredientsDetails(int id)
        {
            var result= await _RecipeDbContext.DishIngredients.FirstOrDefaultAsync(x=>x.Id==id);
            if (result != null)
            {
                DetailsDishIngredients details = new DetailsDishIngredients()
                {
                    Id=result.Id,
                    DishId = (int)result.DishId,
                    IngredientId=result.IngredientId,
                    Quantity=result.Quantity,
                    quantityUnit=result.quantityUnit.ToString(),
                    CreationDate=result.CreationDate,
                    IsDeleted=result.IsDeleted
                };
                return details;
            }
            throw new Exception("not found");
        }

        public Task UpdateOrDeleteDishIngredient(UpdateDishIngredients dt)
        {
            throw new NotImplementedException();
        }
    }
}
