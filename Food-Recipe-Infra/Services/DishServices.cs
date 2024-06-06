using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
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

        public async Task CreateDish(CreateDishDTO createDishDto)
        {
            Dish dish=new Dish()
            {
                Name = createDishDto.Name,
                Description = createDishDto.Description,
                Image=createDishDto.Image,
                CreationDate = createDishDto.CreationDate,
                CategoryId = createDishDto.CategoryId,
                CuisineId=createDishDto.CuisineId,
            };
            await _DishRepos.CreateDish(dish);
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
