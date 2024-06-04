using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IDishIngredientsRepos
    {
        Task<DetailsDishIngredients> GetDishIngredientsDetails(int id);

        Task<List<GetAllDishIngredients>> GetAllDishIngredients();

        Task CreateDishIngredient(DishIngredient dt);

        Task UpdateOrDeleteDishIngredient(DishIngredient dt);
    }
}
