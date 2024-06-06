using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
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

        public async Task CreateCuisine(CreateCuisineDTO createCuisineDto)
        {
            Cuisine cuisine = new Cuisine()
            {
                Title = createCuisineDto.Title,
                Description = createCuisineDto.Description,
                ImageUrl = createCuisineDto.ImageUrl,
                CreationDate = createCuisineDto.CreationDate,
            };
            await _cuisineRepos.CreateCuisine(cuisine);
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
