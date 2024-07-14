using Food_Recipe_Core.DTOs.Authentication;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using Food_Recipe_Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Food_Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IUserServices _user;
        private readonly ICategoryServices _category;
        private readonly ICuisineServices _cuisine;
        private readonly IDishServices _dish;
        private readonly IIngredientServices _ingredient;
        private readonly IDishPreparingStepsServices _preparingSteps;
        private readonly IDishIngredientsServices _DishIngredients;
        private readonly ISubscriptionServices _subscription;
        public SharedController(IUserServices service,
         ICategoryServices category, ICuisineServices cuisine , IDishServices dish
            , IIngredientServices ingredient, IDishPreparingStepsServices preparingSteps
            , IDishIngredientsServices dishIngredients , ISubscriptionServices subscription
            )
        {
            _user = service;
            _category = category;
            _cuisine = cuisine;
            _dish = dish;
            _ingredient = ingredient;
            _preparingSteps = preparingSteps;
            _DishIngredients = dishIngredients;
            _subscription = subscription;
        }

        #region Get

        /// <summary>
        /// Returns all Categories In My Db
        /// </summary>
        /// <response code="200">Returns All the available Categories</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                Log.Information("GetAllCategories Was Called");
                Log.Information("GetAllCategories Was Returned");
                return StatusCode(200, await _category.GetAllCategory());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns One Category Details In My Db
        /// </summary>
        /// <response code="200">Returns the available Category Details</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCategoryDetails(int id)
        {
            try
            {
                Log.Information("GetCategoryDetails Was Called");
                Log.Information("GetCategoryDetails Was Returned");
                return StatusCode(200, await _category.GetCategoryDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Views all Cuisines In My Db
        /// </summary>
        /// <response code="200">Returns the available Cuisines</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCuisines()
        {
            try
            {
                Log.Information("GetAllCuisines Was Called");
                Log.Information("GetAllCuisines Was Returned");
                return StatusCode(200, await _cuisine.GetAllCuisine());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// View a single Cuisine by its Id In My Db
        /// </summary>
        /// <response code="200">Returns the available Cuisine</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetCuisineDetails(int id)
        {
            try
            {
                Log.Information("GetCuisineDetails Was Called");
                Log.Information("GetAllGetCuisineDetailsishes Was Returned");
                return StatusCode(200, await _cuisine.GetDeatilsCuisine(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Dishes In My Db
        /// </summary>
        /// <response code="200">Returns All the available Dishes</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllDishes()
        {
            try
            {
                Log.Information("GetAllDishes Was Called");
                Log.Information("GetAllDishes Was Returned");
                return StatusCode(200, await _dish.GetAllDish());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns one Dish from My Db
        /// </summary>
        /// <response code="200">Returns the available Dish</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetDishDetails(int id)
        {
            try
            {
                Log.Information("GetDishDetails Was Called");
                Log.Information("GetDishDetails Was Returned");
                return StatusCode(200, await _dish.GetDishDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Ingredient In My Db
        /// </summary>
        /// <response code="200">Returns All the available Ingredients</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllIngredient()
        {
            try
            {
                Log.Information("GetAllIngredient Was Called");
                Log.Information("GetAllIngredient Was Returned");
                return StatusCode(200, await _ingredient.GetAllIngredients());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns one IngredientsDetails In My Db
        /// </summary>
        /// <response code="200">Returns the available Ingredient Details</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetIngredientsDetails(int id)
        {
            try
            {
                Log.Information("GetIngredientsDetails Was Called");
                Log.Information("GetIngredientsDetails Was Returned");
                return StatusCode(200, await _ingredient.GetIngredientsDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all DishPreparingSteps In My Db
        /// </summary>
        /// <response code="200">Returns All the available Dish Preparing Steps</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPreparingSteps()
        {
            try
            {
                Log.Information("GetAllPreparingSteps Was Called");
                Log.Information("GetAllPreparingSteps Was Returned");
                return StatusCode(200, await _preparingSteps.GetAllDishPreparingSteps());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns One DishPreparingSteps In My Db
        /// </summary>
        /// <response code="200">Returns the available Dish Preparing Steps</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]{id}")]
        public async Task<IActionResult> GetPreparingStepsDetails(int id)
        {
            try
            {
                Log.Information("GetPreparingStepsDetails Was Called");
                Log.Information("GetPreparingStepsDetails Was Returned");
                return StatusCode(200, await _preparingSteps.GetDishPreparingStepsDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }


        /// <summary>
        /// Returns all DishIngredients In My Db
        /// </summary>
        /// <response code="200">Returns All the available Dish Ingredients</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllDishIngredients()
        {
            try
            {
                Log.Information("GetAllDishIngredients Was Called");
                Log.Information("GetAllDishIngredients Was Returned");
                return StatusCode(200, await _DishIngredients.GetAllDishIngredients());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns a DishIngredient In My Db
        /// </summary>
        /// <response code="200">Returns the available Dish Ingredient</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetDishIngredientDetails(int id)
        {
            try
            {
                Log.Information("GetDishIngredientDetails Was Called");
                Log.Information("GetDishIngredientDetails Was Returned");
                return StatusCode(200, await _DishIngredients.GetDishIngredientsDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Subscriptions In My Db
        /// </summary>
        /// <response code="200">Returns All the available Subscriptions</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSubscription()
        {
            try
            {
                Log.Information("GetAllSubscription Was Called");
                Log.Information("GetAllSubscription Was Returned");
                return StatusCode(200, await _subscription.GetAllSubscriptions());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
        #endregion


        #region Authorization

        /// <summary>
        /// Registers A new User In My Db
        /// </summary>
        /// <response code="200">Returns User is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("Register a new User")]
        public async Task<IActionResult> RegisterANewUser([FromBody] CreateRegisterDTO CreateRegisterDTO)
        {
            if (CreateRegisterDTO == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("Register A New User Was Called");
                    Log.Information("Register A New User Was Returned");
                    await _user.CreateUser(CreateRegisterDTO);
                    return StatusCode(201, "New User Has Been Registered");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion


    }
}
