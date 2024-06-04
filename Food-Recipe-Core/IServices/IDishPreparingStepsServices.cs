using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.DishPreparingSteps;
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

        Task CreateDishPreparingSteps(CreateDishPreparingSteps createstepsDto);

        Task UpdateOrDeleteDishPrepareSteps(UpdateDishPreparingSteps updateStepsDto);
    }
}
