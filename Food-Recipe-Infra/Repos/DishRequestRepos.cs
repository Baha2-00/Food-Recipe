using Food_Recipe_Core.DTOs.DishRequest;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class DishRequestRepos : IDishRequestRepos
    {
        public Task CreateDishRequests(DishRequest createDishRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ViewDishRequests>> ViewDishRequests()
        {
            throw new NotImplementedException();
        }
    }
}
