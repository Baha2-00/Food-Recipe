using Food_Recipe_Core.DTOs.DishRequest;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IDishRequestRepos
    {
        Task<List<ViewDishRequests>> ViewDishRequests();

        Task CreateDishRequests(DishRequest createDishRequestDto);
    }
}
