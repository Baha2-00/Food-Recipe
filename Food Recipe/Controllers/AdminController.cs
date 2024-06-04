using Food_Recipe_Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food_Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserServices _user;
        private readonly ICategoryServices _category;
        private readonly ICuisineServices _cuisine;
        public AdminController(IUserServices service,
         ICategoryServices category , ICuisineServices cuisine)
        {
            _user = service;
            _category = category;
            _cuisine = cuisine;
        }

        /// <summary>
        /// Retrieves all Users In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return StatusCode(200, await _user.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
    }
}
