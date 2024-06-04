﻿using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IDishServices
    {
        Task<GetDishDetailsDTO> GetDishDetails(int id);

        Task<List<GetAllDishDTO>> GetAllDish();

        Task CreateDish(CreateDishDTO createDishDto);

        Task UpdateOrDeleteDish(UpdateDishDTO updateDishDto);
    }
}
