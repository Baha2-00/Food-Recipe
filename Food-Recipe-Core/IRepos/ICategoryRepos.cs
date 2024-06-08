using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface ICategoryRepos
    {
        Task<GetDetailsCategoryDTO> GetCategoryDetails(int id);

        Task<List<GetAllCategoryDTO>> GetAllCategory();

        Task CreateCategory(Category createCateDto);

        Task UpdateOrDeleteCategory(UpdateCategoryDTO dto);
    }
}
