using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IDishPreparingStepsServices
    {
        Task<DishPreparingStepsDetailsDTO> GetDishPreparingStepsDetails(int id);

        Task<List<GetAllDishPreparingSteps>> GetAllDishPreparingSteps();

        Task CreateDishPreparingSteps(CreateDishPreparingSteps DishPreparingStepsDto);

        Task UpdateDishPrepareSteps(UpdateDishPreparingSteps updateStepsDto);
        Task UpdateDishPrepareStepsActivation(int id,bool value);
    }
}
