using Food_Recipe_Core.DTOs.DishRequest;
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
    public class DishRequestServices : IDishRequestServices
    {
        private readonly IDishRequestRepos _dishRequest;
        public DishRequestServices(IDishRequestRepos dishRequest)
        {
            _dishRequest = dishRequest;
        }
        public async Task CreateDishRequests(CreateDishRequest createDishRequestDto)
        {
            DishRequest dishRequest = new DishRequest()
            {
                Title = createDishRequestDto.Title,
                Purpose = createDishRequestDto.Purpose,
                RequestDate = createDishRequestDto.RequestDate,
                Priority = createDishRequestDto.Priority,
                UserId = createDishRequestDto.UserId,
            };
            await _dishRequest.CreateDishRequests(dishRequest);
        }

        public async Task<ViewDishRequests> ViewDishRequest(int id)
        {
            return await _dishRequest.ViewDishRequest(id);
        }
    }
}
