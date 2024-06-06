using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.DTOs.UserSubscriptions;
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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCategoryDetails(int id)
        {
            try
            {
                return StatusCode(200, await _category.GetCategoryDetails(id));
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
        /// <summary>
        /// View a single Cuisine by its Id In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCuisineDetails(int id)
        {
            try
            {
                return StatusCode(200, await _cuisine.GetDeatilsCuisine(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Dishes In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllDishes()
        {
            try
            {
                return StatusCode(200, await _dish.GetAllDish());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns one Dish from My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDishDetails(int id)
        {
            try
            {
                return StatusCode(200, await _dish.GetDishDetails(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Ingredient In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllIngredient()
        {
            try
            {
                return StatusCode(200, await _ingredient.GetAllIngredients());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns one IngredientsDetails In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetIngredientsDetails(int id)
        {
            try
            {
                return StatusCode(200, await _ingredient.GetIngredientsDetails(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all DishPreparingSteps In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPreparingSteps()
        {
            try
            {
                return StatusCode(200, await _preparingSteps.GetAllDishPreparingSteps());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Categories In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPreparingStepsDetails(int id)
        {
            try
            {
                return StatusCode(200, await _preparingSteps.GetDishPreparingStepsDetails(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }


        /// <summary>
        /// Returns all DishIngredients In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllDishIngredients()
        {
            try
            {
                return StatusCode(200, await _DishIngredients.GetAllDishIngredients());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns a DishIngredient In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDishIngredientDetails(int id)
        {
            try
            {
                return StatusCode(200, await _DishIngredients.GetDishIngredientsDetails(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Returns all Subscriptions In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSubscription()
        {
            try
            {
                return StatusCode(200, await _subscription.GetAllSubscriptions());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
        #endregion


        #region Authorization

        [HttpPost]
        [Route("Register a new User")]
        public async Task<IActionResult> CreateNewUser([FromBody] CreateUserDTO createUserDto)
        {
            if (createUserDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    await _user.CreateUser(createUserDto);
                    return StatusCode(201, "New User Has Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        #endregion


    }
}
