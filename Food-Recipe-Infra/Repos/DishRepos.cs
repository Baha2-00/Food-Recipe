using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Google.Protobuf.Compiler;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class DishRepos : IDishRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public DishRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }

        public Task CreateDish(Dish createDishDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllDishDTO>> GetAllDish()
        {
            var query = from v in _RecipeDbContext.Dishs
                        select new GetAllDishDTO
                        {
                            ID=v.Id,
                            Name=v.Name,
                            Description=v.Description,
                            Image=v.Image
                        };
            return await query.ToListAsync();
        }

        public async Task<GetDishDetailsDTO> GetDishDetails(int id)
        {
            var res=await _RecipeDbContext.Dishs.FirstOrDefaultAsync(x=>x.Id==id);
            if (res != null)
            {
                var categ= await _RecipeDbContext.Categories.FirstOrDefaultAsync(x=>x.Id==res.CategoryId);
                var cuis= await _RecipeDbContext.Cuisines.FirstOrDefaultAsync(x=>x.Id==res.CuisineId);
                GetDishDetailsDTO response = new GetDishDetailsDTO()
                {
                    ID=res.Id,
                    Name=res.Name,
                    Description=res.Description,
                    Image=res.Image,
                    CreationDate=res.CreationDate,
                    CategoryName= categ == null ? "No category" : categ.Title,
                    CuisineName= cuis == null ? "No cuisine" : cuis.Title,
                    IsDeleted=res.IsDeleted
                };
                return response;
            }
            throw new Exception("not found");
        }

        public Task UpdateOrDeleteDish(UpdateDishDTO updateDishDto)
        {
            throw new NotImplementedException();
        }
    }
}
