﻿using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class DishPreparingStepsServices : IDishPreparingStepsServices
    {
        private readonly IDishPreparingStepsRepos _PreparingStepsRepos;
        public DishPreparingStepsServices(IDishPreparingStepsRepos PreparingStepsRepos)
        {
            _PreparingStepsRepos = PreparingStepsRepos;
        }

        public Task CreateDishPreparingSteps(CreateDishPreparingSteps DishPreparingStepsDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllDishPreparingSteps>> GetAllDishPreparingSteps()
        {
            return await _PreparingStepsRepos.GetAllDishPreparingSteps();
        }

        public async Task<DishPreparingStepsDetailsDTO> GetDishPreparingStepsDetails(int id)
        {
            return await _PreparingStepsRepos.GetDishPreparingStepsDetails(id);
        }

        public Task UpdateOrDeleteDishPrepareSteps(UpdateDishPreparingSteps updateStepsDto)
        {
            throw new NotImplementedException();
        }
    }
}
