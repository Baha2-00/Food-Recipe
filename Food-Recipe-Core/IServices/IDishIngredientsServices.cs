using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IDishIngredientsServices
    {
        Task<DetailsDishIngredients> GetDishIngredientsDetails(int id);

        Task<List<GetAllDishIngredients>> GetAllDishIngredients();

        Task CreateDishIngredient(CreateDishIngredients dt);

        Task UpdateOrDeleteDishIngredient(UpdateDishIngredients dt);
    }
}
