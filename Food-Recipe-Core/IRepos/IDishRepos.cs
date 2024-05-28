using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IDishRepos
    {
        Task<UpdateDish> GetDishDetails(int id);

        Task<List<GetAllDish>> GetAllDish();

        Task CreateDish(Dish createDishDto);

        Task UpdateOrDeleteDish(Dish updateDishDto);
    }
}
}
