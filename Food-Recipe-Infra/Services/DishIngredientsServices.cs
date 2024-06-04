using Food_Recipe_Core.DTOs.DishIngredients;
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
        public Task CreateDishIngredient(CreateDishIngredients dt)
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

        public Task UpdateOrDeleteDishIngredient(UpdateDishIngredients dt)
        {
            throw new NotImplementedException();
        }
    }
}
