using Food_Recipe_Core.DTOs.Ingredient;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class IngredientRepos : IIngredientRepos
    {
        public Task CreateIngredients(Ingredients createIngredients)
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

        public Task UpdateOrDeleteIngredients(Ingredients updateIngredients)
        {
            throw new NotImplementedException();
        }
    }
}
