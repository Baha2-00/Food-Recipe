using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
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

        public Task CreateDishIngredient(CreateDishIngredients dt)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllDishIngredients>> GetAllDishIngredients()
        {
            return await _DishIngredientsRepos.GetAllDishIngredients();
        }

        public async Task<DetailsDishIngredients> GetDishIngredientsDetails(int id)
        {
            return await _DishIngredientsRepos.GetDishIngredientsDetails(id);
        }

        public Task UpdateOrDeleteDishIngredient(UpdateDishIngredients dt)
        {
            throw new NotImplementedException();
        }
    }
}
