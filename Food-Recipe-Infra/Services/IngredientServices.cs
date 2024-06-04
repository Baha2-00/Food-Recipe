using Food_Recipe_Core.DTOs.Ingredient;
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
        public Task CreateIngredients(CreateIngredient createIngredientsDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetALLIngredients>> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Task<GetIngredientDetails> GetIngredientsDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteIngredients(UpdateIngredients updateIngredientsDto)
        {
            throw new NotImplementedException();
        }
    }
}
