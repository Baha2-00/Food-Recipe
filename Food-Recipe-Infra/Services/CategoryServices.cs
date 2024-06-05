using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Infra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepos _Catrepos;
        public CategoryServices(ICategoryRepos Catrepos)
        {
            _Catrepos = Catrepos;
        }

        public Task CreateCategory(CreateCategoryDTO createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllCategoryDTO>> GetAllCategory()
        {
           return await _Catrepos.GetAllCategory();
        }

        public async Task<GetDetailsCategoryDTO> GetCategoryDetails(int id)
        {
            return await _Catrepos.GetCategoryDetails(id);
        }

        public Task UpdateOrDeleteCategory(UpdateCategoryDTO updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
