using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using Food_Recipe_Infra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class DishIngredientsServices : IDishIngredientsServices
    {
        private readonly IDishIngredientsRepos _DishIngredientsRepos;
        public DishIngredientsServices(IDishIngredientsRepos dishIngredientsRepos)
        {
            _DishIngredientsRepos = dishIngredientsRepos;
        }

        public async Task CreateDishIngredient(CreateDishIngredients dt)
        {
            DishIngredient dishIngredient=new DishIngredient()
            {
                DishId=dt.DishId,
                IngredientId=dt.IngredientId,
                Quantity=dt.Quantity,
                quantityUnit=dt.quantityUnit,
                CreationDate=dt.CreationDate
            };
            await _DishIngredientsRepos.CreateDishIngredient(dishIngredient);
        }

        public async Task<List<GetAllDishIngredients>> GetAllDishIngredients()
        {
            return await _DishIngredientsRepos.GetAllDishIngredients();
        }

        public async Task<DetailsDishIngredients> GetDishIngredientsDetails(int id)
        {
            return await _DishIngredientsRepos.GetDishIngredientsDetails(id);
        }

        public async Task UpdateOrDeleteDishIngredient(UpdateDishIngredients dt)
        {
            var dishing = await _DishIngredientsRepos.GetDishIngredientsByID(dt.Id);
            if (dishing != null)
            {
                if (dt.DishId != null)
                {
                    dishing.DishId = dt.DishId;
                }
                if (dt.IngredientId != null)
                {
                    dishing.IngredientId = dt.IngredientId;
                }
                if (dt.quantityUnit != null)
                {
                    dishing.quantityUnit = dt.quantityUnit;
                }
                if (dt.Quantity != null)
                {
                    dishing.Quantity = dt.Quantity;
                }
                await _DishIngredientsRepos.UpdateOrDeleteDishIngredient(dishing);
            }
            else
            {
                throw new Exception("dish ingredientS Does not Exist");
            }
        }
    }
}
