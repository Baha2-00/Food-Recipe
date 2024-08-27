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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food_Recipe_Infra.Repos
{
    public class DishRepos : IDishRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public DishRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }

        public async Task CreateDish(Dish createDishDto)
        {
            _RecipeDbContext.Dishs.Add(createDishDto);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllDishDTO>> GetAllDish()
        {
            var query = from v in _RecipeDbContext.Dishs
                        where v.IsDeleted== false
                        select new GetAllDishDTO
                        {
                            ID=v.Id,
                            Name=v.Name,
                            Description=v.Description,
                            Image=$"https://localhost:44332/Images/{v.Image}",
                            IngredientName=v.IngredientName,
                            Quantity=v.Quantity,
                            preparingStepsDescription=v.preparingStepsDescription,
                            IsDeleted=v.IsDeleted
                        };
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Dish> GetDishByID(int id)
        {
            return await _RecipeDbContext.Dishs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GetDishDetailsDTO> GetDishDetails(int id)
        {
            var res=await _RecipeDbContext.Dishs.FirstOrDefaultAsync(x=>x.Id==id);
            if (res != null)
            {
                var categ= await _RecipeDbContext.Categories.FirstOrDefaultAsync(x=>x.Id==res.CategoryId);
                var cuis= await _RecipeDbContext.Cuisines.FirstOrDefaultAsync(x=>x.Id==res.CuisineId);
                var user= await _RecipeDbContext.Users.FirstOrDefaultAsync(x=>x.Id==res.UserId);
                GetDishDetailsDTO response = new GetDishDetailsDTO()
                {
                    ID=res.Id,
                    Name=res.Name,
                    Description=res.Description,
                    Image= $"https://localhost:44332/Images/{res.Image}",
                    CreationDate=res.CreationDate,
                    CategoryName= categ == null ? "No category" : categ.Title,
                    CuisineName= cuis == null ? "No cuisine" : cuis.Title,
                    UserName=user==null? "No User" : user.FirstName,
                    IsApproved=res.IsApproved,
                    IngredientName=res.IngredientName,
                    Quantity=res.Quantity,
                    preparingStepsDescription=res.preparingStepsDescription
                };
                return response;
            }
            throw new Exception("not found");
        }

        public async Task<List<GetAllDishDTO>> GetDishesWithApprove()
        {
            var query = from v in _RecipeDbContext.Dishs
                        where v.IsDeleted == true
                        select new GetAllDishDTO
                        {
                            ID = v.Id,
                            Name = v.Name,
                            Description = v.Description,
                            Image = $"https://localhost:44332/Images/{v.Image}",
                            IngredientName = v.IngredientName,
                            Quantity = v.Quantity,
                            preparingStepsDescription = v.preparingStepsDescription,
                            IsDeleted = v.IsDeleted
                        };
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<DishUserDTO>> GetUserDishByUserId(int Id)
        {
            if (Id == -1)
            {
                var query2 = from dish in _RecipeDbContext.Dishs
                             where
                              dish.IsDeleted == false
                             select new DishUserDTO
                             {
                                 ID = dish.Id,
                                 Name = dish.Name,
                                 Description = dish.Description,
                                 CreationDate = dish.CreationDate.ToString(),
                                 Status = dish.IsApproved == true ? "Accepted" :
                                 dish.IsApproved == false ? "Rejected" : "Pending"
                             };
                return await query2.ToListAsync();
            }
            var query = from dish in _RecipeDbContext.Dishs
                        where dish.UserId == Id
                        && dish.IsDeleted == false
                        select new DishUserDTO
                        {
                            ID = dish.Id,
                            Name = dish.Name,
                            Description = dish.Description,
                            CreationDate = dish.CreationDate.ToString(),
                            Status = dish.IsApproved == true ? "Accepted" :
                            dish.IsApproved == false ? "Rejected" : "Pending"
                        };
            return await query.ToListAsync();
        }

        public async Task UpdateOrDeleteDish<T>(T inp)
        {
                _RecipeDbContext.Update(inp);
                await _RecipeDbContext.SaveChangesAsync();

        }
    }
}
