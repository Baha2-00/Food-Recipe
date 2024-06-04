using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IDishPreparingStepsRepos
    {
        Task<DishPreparingStepsDetailsDTO> GetDishPreparingStepsDetails(int id);

        Task<List<GetAllDishPreparingSteps>> GetAllDishPreparingSteps();

        Task CreateDishPreparingSteps(DishPreparingSteps createstepsDto);

        Task UpdateOrDeleteDishPrepareSteps(DishPreparingSteps updateStepsDto);
    }
}
