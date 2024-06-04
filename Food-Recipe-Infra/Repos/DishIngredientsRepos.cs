using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class DishIngredientsRepos : IDishIngredientsRepos
    {
        public Task CreateDishIngredient(DishIngredient dt)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllDishIngredients>> GetAllDishIngredients()
        {
            throw new NotImplementedException();
        }

        public Task<DetailsDishIngredients> GetDishIngredientsDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteDishIngredient(DishIngredient dt)
        {
            throw new NotImplementedException();
        }
    }
}
