using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
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

        public async Task CreateDishPreparingSteps(CreateDishPreparingSteps DishPreparingStepsDto)
        {
            DishPreparingSteps dishPreparingSteps=new DishPreparingSteps()
            {
                serial= DishPreparingStepsDto.serial,
                Title=DishPreparingStepsDto.Title,
                desc= DishPreparingStepsDto.desc,
                attachment= DishPreparingStepsDto.attachment,
                CreationDate= DateTime.Now,
                DishId= DishPreparingStepsDto.DishId
            };
            await _PreparingStepsRepos.CreateDishPreparingSteps(dishPreparingSteps);
        }

        public async Task<List<GetAllDishPreparingSteps>> GetAllDishPreparingSteps()
        {
            return await _PreparingStepsRepos.GetAllDishPreparingSteps();
        }

        public async Task<DishPreparingStepsDetailsDTO> GetDishPreparingStepsDetails(int id)
        {
            return await _PreparingStepsRepos.GetDishPreparingStepsDetails(id);
        }

        public async Task UpdateDishPrepareSteps(UpdateDishPreparingSteps updateStepsDto)
        {
            var query = await _PreparingStepsRepos.GetPreparingStepsByID(updateStepsDto.Id);

            if (query != null)
            {
                query.serial = updateStepsDto.serial;
                query.Title = updateStepsDto.Title;
                query.desc = updateStepsDto.desc;
                query.attachment = updateStepsDto.attachment;
                query.DishId = updateStepsDto.DishId;

                await _PreparingStepsRepos.UpdateOrDeleteDishPrepareSteps(query);
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }

        public async Task UpdateDishPrepareStepsActivation(int id, bool value)
        {
            var prepar = await _PreparingStepsRepos.GetPreparingStepsByID(id);
            if (prepar != null)
            {
                prepar.IsDeleted = value;
                await _PreparingStepsRepos.UpdateOrDeleteDishPrepareSteps(prepar);
            }
            else
            {
                throw new Exception("Dish Steps is not found");
            }
        }
    }
}
