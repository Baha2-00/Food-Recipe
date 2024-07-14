using Food_Recipe_Core.DTOs.Ingredient;
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
    public class IngredientServices : IIngredientServices
    {
        private readonly IIngredientRepos _IngredientRepos;

        public IngredientServices(IIngredientRepos ingredientRepos)
        {
            _IngredientRepos = ingredientRepos;
        }

        public async Task CreateIngredients(CreateIngredient createIngredientsDto)
        {
            Ingredients ingredients = new Ingredients()
            {
                Name = createIngredientsDto.Name,
                Description = createIngredientsDto.Description,
                Title = createIngredientsDto.Title,
                Image=createIngredientsDto.Image,
                CreationDate=createIngredientsDto.CreationDate
            };
            await _IngredientRepos.CreateIngredients(ingredients);
        }

        public async Task<List<GetALLIngredients>> GetAllIngredients()
        {
            return await _IngredientRepos.GetAllIngredients();
        }

        public async Task<GetIngredientDetails> GetIngredientsDetails(int id)
        {
            return await _IngredientRepos.GetIngredientsDetails(id);
        }

        public async Task UpdateIngredientActivation(int id, bool value)
        {
            var que= await _IngredientRepos.GetIngredientsByID(id);
            if (que != null)
            {
                que.IsDeleted = value;
                await _IngredientRepos.UpdateOrDeleteIngredients(que);
            }
            else
            {
                throw new Exception("Ingredient does not exist");
            }
        }

        public async Task UpdateIngredients(UpdateIngredients updateIngredientsDto)
        {
            var query = await _IngredientRepos.GetIngredientsByID(updateIngredientsDto.Id);

            if (query != null)
            {
                query.Name = updateIngredientsDto.Name;
                query.Description = updateIngredientsDto.Description;
                query.Image = updateIngredientsDto.Image;
                query.Title = updateIngredientsDto.Title;

                await _IngredientRepos.UpdateOrDeleteIngredients(query);
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }
    }
}
