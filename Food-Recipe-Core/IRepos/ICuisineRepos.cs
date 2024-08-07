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
        Task<Cuisine> GetCuisineById(int id);
        Task<GetDeatilsCuisineDTO> GetDeatilsCuisine(int id);

        Task<List<GetAllCuisineDTO>> GetAllCuisine();

        Task CreateCuisine(Cuisine createCuisineDto);

        Task UpdateCuisine<U>(U input);
    }
}
