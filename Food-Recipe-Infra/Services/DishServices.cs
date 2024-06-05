using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class DishServices : IDishServices
    {
        private readonly IDishRepos _DishRepos;
        public DishServices(IDishRepos dishRepos)
        {
            _DishRepos = dishRepos;
        }

        public Task CreateDish(CreateDishDTO createDishDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllDishDTO>> GetAllDish()
        {
            return await _DishRepos.GetAllDish();
        }

        public async Task<GetDishDetailsDTO> GetDishDetails(int id)
        {
            return await _DishRepos.GetDishDetails(id);
        }

        public Task UpdateOrDeleteDish(UpdateDishDTO updateDishDto)
        {
            throw new NotImplementedException();
        }
    }
}
