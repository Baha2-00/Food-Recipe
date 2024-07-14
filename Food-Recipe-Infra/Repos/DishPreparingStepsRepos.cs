using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food_Recipe_Infra.Repos
{
    public class DishPreparingStepsRepos : IDishPreparingStepsRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public DishPreparingStepsRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }

        public async Task CreateDishPreparingSteps(DishPreparingSteps createstepsDto)
        {
            _RecipeDbContext.DishPreparingStep.Add(createstepsDto);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllDishPreparingSteps>> GetAllDishPreparingSteps()
        {
            var query = from prep in _RecipeDbContext.DishPreparingStep
                        select new GetAllDishPreparingSteps
                        {
                            Id= prep.Id,
                            serial=prep.serial,
                            Title= prep.Title,
                            desc=prep.desc,
                            attachment=prep.attachment
                        };
            return await query.ToListAsync();
        }

        public async Task<DishPreparingStepsDetailsDTO> GetDishPreparingStepsDetails(int id)
        {
            var result = await _RecipeDbContext.DishPreparingStep.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                var wow=await _RecipeDbContext.Dishs.FirstOrDefaultAsync(c => c.Id == result.DishId);
                DishPreparingStepsDetailsDTO response = new DishPreparingStepsDetailsDTO()
                {
                    Id = result.Id,
                    serial = result.serial,
                    Title = result.Title,
                    desc= result.desc,
                    attachment=result.attachment,
                    CreationDate = result.CreationDate,
                    DishName = wow == null ? "No Dish" : wow.Name,
                    IsDeleted = result.IsDeleted
                };
                return response;
            }
            throw new Exception("not found");
        }

        public async Task<DishPreparingSteps> GetPreparingStepsByID(int id)
        {
            return await _RecipeDbContext.DishPreparingStep.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOrDeleteDishPrepareSteps(UpdateDishPreparingSteps updateStepsDto)
        {
            var query = await _RecipeDbContext.DishPreparingStep.FindAsync(updateStepsDto.Id);

            if (query != null)
            {
                query.serial = updateStepsDto.serial;
                query.Title = updateStepsDto.Title;
                query.desc = updateStepsDto.desc;
                query.attachment = updateStepsDto.attachment;
                query.DishId = updateStepsDto.DishId;
                query.IsDeleted = updateStepsDto.IsDeleted;
                _RecipeDbContext.Update(query);
                await _RecipeDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }
    }
}
