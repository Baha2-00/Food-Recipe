﻿using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IIngredientServices
    {
        Task<GetIngredientDetails> GetIngredientsDetails(int id);

        Task<List<GetALLIngredients>> GetAllIngredients();

        Task CreateIngredients(CreateIngredient createIngredientsDto);

        Task UpdateIngredients(UpdateIngredients updateIngredientsDto);
        Task UpdateIngredientActivation(int id, bool value);
    }
}
