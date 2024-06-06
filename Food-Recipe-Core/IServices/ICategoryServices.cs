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
        Task<GetDetailsCategoryDTO> GetCategoryDetails(int id);

        Task<List<GetAllCategoryDTO>> GetAllCategory();

        Task CreateCategory(CreateCategoryDTO createCateDto);

        Task UpdateOrDeleteCategory(UpdateCategoryDTO updateCategoryDto);
    }
}
