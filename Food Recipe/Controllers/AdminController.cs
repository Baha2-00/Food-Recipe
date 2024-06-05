using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
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
        private readonly IDishServices _dish;
        private readonly IIngredientServices _ingredient;
        private readonly IDishPreparingStepsServices _preparingSteps;
        private readonly IDishIngredientsServices _DishIngredients;
        private readonly ISubscriptionServices _subscription;
        private readonly IUserSubscriptionServices _userSubscription;
        private readonly ILoginServices _login;

        public AdminController(IUserServices service,
         ICategoryServices category, ICuisineServices cuisine, IDishServices dish
            , IIngredientServices ingredient, IDishPreparingStepsServices preparingSteps
            , IDishIngredientsServices dishIngredients, ISubscriptionServices subscription,
            IUserSubscriptionServices userSubscription , ILoginServices login)
        {
            _user = service;
            _category = category;
            _cuisine = cuisine;
            _dish = dish;
            _ingredient = ingredient;
            _preparingSteps = preparingSteps;
            _DishIngredients = dishIngredients;
            _subscription = subscription;
            _userSubscription = userSubscription;
            _login = login;
        }

        /// <summary>
        /// Retrieves all Users In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
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

        /// <summary>
        /// Retrieves one User by id In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        /// 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUsersByid(int id)
        {
            try
            {
                return StatusCode(200, await _user.GetUserProfile(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all Users In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUserSubscriptions()
        {
            try
            {
                return StatusCode(200, await _userSubscription.GetAllUserSubscriptions());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUserSubscriptionsDetails(int id)
        {
            try
            {
                return StatusCode(200, await _userSubscription.GetUserSubscriptionsDetails(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
    }
}
