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
                CreationDate = DateTime.Now
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

        public async Task UpdateCuisineActivation(int Id, bool value)
        {
            var cuisine = await _cuisineRepos.GetCuisineById(Id);
            if (cuisine != null)
            {
                cuisine.IsDeleted = value;
                await _cuisineRepos.UpdateCuisine(cuisine);
            }
            else
            {
                throw new Exception("cuisine Does not Exist");
            }
        }

        public async Task UpdateOrDeleteCuisine(UpdateCuisineDTO dto)
        {
            var cuisine = await _cuisineRepos.GetCuisineById(dto.Id);
            if (cuisine != null)
            {
                if (dto.Title != null && !dto.Title.Equals(""))
                {
                    cuisine.Title = dto.Title;
                }
                if (!string.IsNullOrEmpty(dto.Description))
                {
                    cuisine.Description = dto.Description;
                }
                if (!string.IsNullOrEmpty(dto.ImageUrl))
                {
                    cuisine.ImageUrl = dto.ImageUrl;
                }
                await _cuisineRepos.UpdateCuisine(cuisine);
            }
            else
            {
                throw new Exception("cuisine Does not Exist");
            }
        }
    }
}
