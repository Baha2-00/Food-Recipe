using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class CuisineServices : ICuisineServices
    {
        private readonly ICuisineRepos _cuisineRepos;
        public CuisineServices(ICuisineRepos Cuisine)
        {
            _cuisineRepos = Cuisine;
        }

        public Task CreateCuisine(CreateCuisineDTO createCuisineDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllCuisineDTO>> GetAllCuisine()
        {
           return await _cuisineRepos.GetAllCuisine();
        }

        public async Task<GetDeatilsCuisineDTO> GetDeatilsCuisine(int id)
        {
            return await _cuisineRepos.GetDeatilsCuisine(id);
        }

        public Task UpdateOrDeleteCuisine(UpdateCuisineDTO dt)
        {
            throw new NotImplementedException();
        }
    }
}
