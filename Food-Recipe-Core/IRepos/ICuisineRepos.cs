﻿using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface ICuisineRepos
    {
        Task<UpdateAndGetDeatilsCuisine> GetDeatilsCuisine(int id);

        Task<List<GetAllCuisine>> GetAllCuisine();

        Task CreateCuisine(Cuisine createCuisineDto);

        Task UpdateOrDeleteCuisine(Cuisine dt);
    }
}
