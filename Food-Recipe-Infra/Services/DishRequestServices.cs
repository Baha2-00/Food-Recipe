using Food_Recipe_Core.DTOs.DishRequest;
using Food_Recipe_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class DishRequestServices : IDishRequestServices
    {
        public Task CreateDishRequests(CreateDishRequest createDishRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ViewDishRequests>> ViewDishRequests()
        {
            throw new NotImplementedException();
        }
    }
}
