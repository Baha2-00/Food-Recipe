using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class DishPreparingStepsRepos : IDishPreparingStepsRepos
    {
        public Task CreateDishPreparingSteps(DishPreparingSteps createstepsDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllDishPreparingSteps>> GetAllDishPreparingSteps()
        {
            throw new NotImplementedException();
        }

        public Task<DishPreparingStepsDetailsDTO> GetDishPreparingStepsDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteDishPrepareSteps(DishPreparingSteps updateStepsDto)
        {
            throw new NotImplementedException();
        }
    }
}
