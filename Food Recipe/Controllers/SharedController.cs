using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using Food_Recipe_Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food_Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IUserServices _user;
        private readonly ICategoryServices _category;
        private readonly ICuisineServices _cuisine;
        public SharedController(IUserServices service,
         ICategoryServices category, ICuisineServices cuisine)
        {
            _user = service;
            _category = category;
            _cuisine = cuisine;
        }

        /// <summary>
        /// Returns all Categories In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                return StatusCode(200, await _category.GetAllCategory());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Views all Cuisines In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCuisines()
        {
            try
            {
                return StatusCode(200, await _cuisine.GetAllCuisine());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
    }
}
