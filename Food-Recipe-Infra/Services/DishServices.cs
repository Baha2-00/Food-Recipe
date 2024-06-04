using Food_Recipe_Core.DTOs.Dish;
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
        public Task CreateDish(CreateDishDTO createDishDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllDishDTO>> GetAllDish()
        {
            throw new NotImplementedException();
        }

        public Task<GetDishDetailsDTO> GetDishDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteDish(UpdateDishDTO updateDishDto)
        {
            throw new NotImplementedException();
        }
    }
}
