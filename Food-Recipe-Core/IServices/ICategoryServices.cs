using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface ICategoryServices
    {
        Task<GetDetailsCategory> GetCategoryDetails(int id);

        Task<List<GetAllCategory>> GetAllDish();

        Task createCategory(CreateCategory createCategoryDto);

        Task UpdateOrDeleteCategory(GetDetailsCategory updateCategoryDto);
    }
}
