using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IDishServices
    {
        Task<UpdateDish> GetDishDetails(int id);

        Task<List<GetAllDish>> GetAllDish();

        Task CreateDish(CreateDish createDishDto);

        Task UpdateOrDeleteDish(UpdateDish updateDishDto);
    }
}
