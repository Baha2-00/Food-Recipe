using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.DTOs.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface ICuisineServices
    {
        Task<GetDeatilsCuisineDTO> GetDeatilsCuisine(int id);

        Task<List<GetAllCuisineDTO>> GetAllCuisine();

        Task CreateCuisine(CreateCuisineDTO createCuisineDto);

        Task UpdateOrDeleteCuisine(UpdateCuisineDTO dto);
    }
}
