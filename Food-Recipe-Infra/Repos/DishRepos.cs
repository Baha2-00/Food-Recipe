using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class DishRepos : IDishRepos
    {
        public Task CreateDish(Dish createDishDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllDishDTO>> GetAllDish()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateDishDTO> GetDishDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteDish(Dish updateDishDto)
        {
            throw new NotImplementedException();
        }
    }
}
