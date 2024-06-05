using Food_Recipe_Core.DTOs.Ingredient;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
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

        public Task CreateIngredients(CreateIngredient createIngredientsDto)
        {
            throw new NotImplementedException();
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
