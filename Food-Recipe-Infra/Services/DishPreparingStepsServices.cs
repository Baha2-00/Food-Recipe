using Food_Recipe_Core.DTOs.DishPreparingSteps;
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
        public Task CreateDishPreparingSteps(CreateDishPreparingSteps createstepsDto)
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

        public Task UpdateOrDeleteDishPrepareSteps(UpdateDishPreparingSteps updateStepsDto)
        {
            throw new NotImplementedException();
        }
    }
}
