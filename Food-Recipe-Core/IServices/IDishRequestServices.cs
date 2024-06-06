using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.DishRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IDishRequestServices
    {

        Task<ViewDishRequests> ViewDishRequest(int id);

        Task CreateDishRequests(CreateDishRequest createDishRequestDto);

    }
}
