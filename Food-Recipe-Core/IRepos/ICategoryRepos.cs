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
        Task<GetDetailsCategory> GetCategoryDetails(int id);

        Task<List<GetAllCategory>> GetAllDish();

        Task createCategory(Category createCategoryDto);

        Task UpdateOrDeleteCategory(Category updateCategoryDto);
    }
}
