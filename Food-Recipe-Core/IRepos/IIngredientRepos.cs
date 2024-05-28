﻿using Food_Recipe_Core.DTOs.Ingredient;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IIngredientRepos
    {
        Task<UpdateIngredients> GetIngredientsDetails(int id);

        Task<List<GetALLIngredients>> GetAllIngredients();

        Task CreateIngredients(Ingredients createIngredients);

        Task UpdateOrDeleteIngredients(Ingredients updateIngredients);
    }
}