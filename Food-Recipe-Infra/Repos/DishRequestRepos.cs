using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.DishRequest;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class DishRequestRepos : IDishRequestRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public DishRequestRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateDishRequests(DishRequest createDishRequestDto)
        {
            _RecipeDbContext.DishRequests.Add(createDishRequestDto);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<ViewDishRequests> ViewDishRequest(int id)
        {
            var res = await _RecipeDbContext.DishRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                ViewDishRequests response = new ViewDishRequests()
                {
                    Id = res.Id,
                    Title= res.Title,
                    Purpose= res.Purpose,
                    RequestDate=res.RequestDate,
                    Priority=res.Priority.ToString(),
                    CreationDate=res.CreationDate,
                    IsDeleted=res.IsDeleted,
                    UserId=res.UserId
                };
                return response;
            }
            throw new Exception("not found");
        }
    }
}
