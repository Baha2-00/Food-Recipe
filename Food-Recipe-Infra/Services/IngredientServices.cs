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

        public Task UpdateOrDeleteIngredients(UpdateIngredients updateIngredientsDto)
        {
            throw new NotImplementedException();
        }
    }
}
