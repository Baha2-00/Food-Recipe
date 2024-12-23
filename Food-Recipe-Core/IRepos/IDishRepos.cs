﻿using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IDishRepos
    {
        Task<List<DishUserDTO>> GetUserDishByUserId(int Id);
        Task<Dish> GetDishByID(int id);
        Task<GetDishDetailsDTO> GetDishDetails(int id);

        Task<List<GetAllDishDTO>> GetAllDish();
        Task<List<GetAllDishDTO>> GetDishesWithApprove();

        Task CreateDish(Dish createDishDto);

        Task UpdateOrDeleteDish<T>(T inp);
    }
}

