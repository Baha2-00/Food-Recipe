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
        private readonly IUserRepos _UserRepos;
        public DishServices(IDishRepos dishRepos , IUserRepos userRepos)
        {
            _DishRepos = dishRepos;
            _UserRepos = userRepos;
        }

        public async Task CreateDish(CreateDishDTO createDishDto)
        {
            Dish dish=new Dish()
            {
                Name = createDishDto.Name,
                Description = createDishDto.Description,
                Image=createDishDto.Image,
                CreationDate = DateTime.Now,
                CategoryId = createDishDto.CategoryId,
                CuisineId=createDishDto.CuisineId,
                UserId=createDishDto.UserId,
                IngredientName=createDishDto.IngredientName,
                Quantity=createDishDto.Quantity,
                preparingStepsDescription=createDishDto.preparingStepsDescription,
                IsDeleted=true
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

        public async Task<List<GetAllDishDTO>> GetDishesWithApprove()
        {
            return await _DishRepos.GetDishesWithApprove();
        }

        public async Task<List<DishUserDTO>> GetUserDishByUserId(int Id)
        {
            var user = await _UserRepos.GetUserById(Id);
            if (user != null || Id == -1)
            {
                return await _DishRepos.GetUserDishByUserId(Id);
            }
            else
            {
                throw new Exception("Blog Dose not Exisit");
            }
        }

        public async Task UpdateDish(UpdateDishDTO updateDishDto)
        {
            var query = await _DishRepos.GetDishByID(updateDishDto.Id);

            if (query != null)
            {
                query.Name = updateDishDto.Name;
                query.Description = updateDishDto.Description;
                query.Image = updateDishDto.Image;

                await _DishRepos.UpdateOrDeleteDish(query);
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }

        public async Task UpdateDishActivation(int id, bool value)
        {
            var dish=await _DishRepos.GetDishByID(id);
            if (dish != null)
            {
                dish.IsDeleted = value;
                await _DishRepos.UpdateOrDeleteDish(dish);
            }
            else
            {
                throw new Exception("Dish is not found");
            }
        }
    }
}
