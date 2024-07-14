using Food_Recipe_Core.DTOs.Authentication;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.Login;
using Food_Recipe_Core.DTOs.Subscription;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
         ICategoryServices category, ICuisineServices cuisine, IDishServices dish,
         IIngredientServices ingredient, IDishPreparingStepsServices preparingSteps,
         IDishIngredientsServices dishIngredients, ISubscriptionServices subscription,
         IUserSubscriptionServices userSubscription, ILoginServices login)
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

        #region Get

        /// <summary>
        /// Retrieves all The Users In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                Log.Information("GetAllUsers Was Called");
                Log.Information("GetAllUsers Was Returned");
                return StatusCode(200, await _user.GetAllUsers());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves one User by id In My Db
        /// </summary>
        /// <response code="200">Returns the available users By ID</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        /// 
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetUsersByid([FromRoute] int id)
        {
            try
            {
                Log.Information("GetUsersByid Was Called");
                Log.Information("GetUsersByid Was Returned");
                return StatusCode(200, await _user.GetUserProfile(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all UserSubscriptions In My Db
        /// </summary>
        /// <response code="200">Returns the available userSubscription</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllUserSubscriptions()
        {
            try
            {
                Log.Information("GetAllUserSubscriptions Was Called");
                Log.Information("GetAllUserSubscriptions Was Returned");
                return StatusCode(200, await _userSubscription.GetAllUserSubscriptions());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves One UserSubscriptions By It's ID In My Db
        /// </summary>
        /// <response code="200">Returns the available userSubscription</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetUserSubscriptionsDetails([FromRoute] int id)
        {
            try
            {
                Log.Information("GetUserSubscriptionsDetails Was Called");
                Log.Information("GetUserSubscriptionsDetails Was Returned");
                return StatusCode(200, await _userSubscription.GetUserSubscriptionsDetails(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
        #endregion


        #region Create

        /// <summary>
        /// Creates A New Admin In My Db
        /// </summary>
        /// <response code="200">Returns Admin Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewAdmin")]
        public async Task<IActionResult> CreateNewAdmin([FromBody] CreateRegisterDTO createAdminDto)
        {
            if (createAdminDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateNewAdmin Was Called");
                    Log.Information("CreateNewAdmin Was Returned");
                    await _user.CreateAdmin(createAdminDto);
                    return StatusCode(201, "New Admin Has Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New Category In My Db
        /// </summary>
        /// <response code="200">Returns Category Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewCategory")]
        public async Task<IActionResult> CreateNewCategory([FromBody] CreateCategoryDTO createCateDto)
        {
            if (createCateDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateNewCategory Was Called");
                    Log.Information("CreateNewCategory Was Returned");
                    await _category.CreateCategory(createCateDto);
                    return StatusCode(201, "New Category Has Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New Cuisine In My Db
        /// </summary>
        /// <response code="200">Returns Cuisine Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewCuisine")]
        public async Task<IActionResult> CreateNewCuisine([FromBody] CreateCuisineDTO createCuisDto)
        {
            if (createCuisDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateNewCuisine Was Called");
                    Log.Information("CreateNewCuisine Was Returned");
                    await _cuisine.CreateCuisine(createCuisDto);
                    return StatusCode(201, "New Cuisine Has Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New Dish In My Db
        /// </summary>
        /// <response code="200">Returns A New Dish Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewDish")]
        public async Task<IActionResult> CreateDish([FromBody] CreateDishDTO createDishDto)
        {
            if (createDishDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateDish Was Called");
                    Log.Information("CreateDish Was Returned");
                    await _dish.CreateDish(createDishDto);
                    return StatusCode(201, "New Dish Has Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New Subscription In My Db
        /// </summary>
        /// <response code="200">Returns Subscription Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewSubscription")]
        public async Task<IActionResult> CreateNewSubscription([FromBody] CreateSubscription createSubscriptionDto)
        {
            if (createSubscriptionDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateNewSubscription Was Called");
                    Log.Information("CreateNewSubscription Was Returned");
                    await _subscription.CreateSubscription(createSubscriptionDto);
                    return StatusCode(201, "New Subscription Has Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New UserSubscription In My Db
        /// </summary>
        /// <response code="200">Returns UserSubscription Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewUserSubscription")]
        public async Task<IActionResult> CreateNewUserSubscription([FromBody] CreateUserSubscriptions createUserSubsDto)
        {
            if (createUserSubsDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateNewUserSubscription Was Called");
                    Log.Information("CreateNewUserSubscription Was Returned");
                    await _userSubscription.CreateUserSubscriptions(createUserSubsDto);
                    return StatusCode(201, "New UserSubscription Has Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Logs You To website
        /// </summary>
        /// <response code="200">Returns login Is done</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("LoginToSite")]
        public async Task<IActionResult> LoginToSite([FromBody] AuthenticationDTO input)
        {
            if (input == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    var token = await _user.GenerateUserAccessToken(input);
                    return StatusCode(200, token);
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }


        #endregion


        #region Update And Delete


        /// <summary>
        /// Updates Admin In My Db
        /// </summary>
        /// <response code="200">Returns Admin Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin([FromBody] UpdateUser dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateAmin Was Called");
                    Log.Information("UpdateAmin Was Returned");
                    await _user.UpdateOrDeleteUser(dto);
                    return StatusCode(201, "Admin Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Category In My Db
        /// </summary>
        /// <response code="200">Returns Category Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateCategory Was Called");
                    Log.Information("UpdateCategory Was Returned");
                    await _category.UpdateOrDeleteCategory(dto);
                    return StatusCode(201, "Category Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Category Activation In My Db
        /// </summary>
        /// <response code="200">Returns Category Activation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCategoryActivation([FromQuery]int Id,[FromQuery]bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateCategory Activate Was Called");
                    Log.Information("UpdateCategory Activate Was Returned");
                    await _category.UpdateCategoryActivation(Id, value);
                    return StatusCode(201, "Category Activation Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Cuisine In My Db
        /// </summary>
        /// <response code="200">Returns Cuisine Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("UpdateCuisine")]
        public async Task<IActionResult> UpdateCuisine([FromBody] UpdateCuisineDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateCuisine Was Called");
                    Log.Information("UpdateCuisine Was Returned");
                    await _cuisine.UpdateOrDeleteCuisine(dto);
                    return StatusCode(201, "Cuisine Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Cuisine In My Db
        /// </summary>
        /// <response code="200">Returns Cuisine Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("UpdateCuisineActivate")]
        public async Task<IActionResult> UpdateCuisineActivate([FromQuery] int Id, [FromQuery] bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateCuisine Was Called");
                    Log.Information("UpdateCuisine Was Returned");
                    await _cuisine.UpdateCuisineActivation(Id,value);
                    return StatusCode(201, "Cuisine Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Category Activation In My Db
        /// </summary>
        /// <response code="200">Returns Category Activation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCuisineActivation([FromQuery] int Id, [FromQuery] bool value)
        {
            if (Id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateCategory Activate Was Called");
                    Log.Information("UpdateCategory Activate Was Returned");
                    await _cuisine.UpdateCuisineActivation(Id, value);
                    return StatusCode(201, "Category Activation Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Subscription In My Db
        /// </summary>
        /// <response code="200">Returns Subscription Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("UpdateSubscription")]
        public async Task<IActionResult> UpdateSubscription([FromBody] UpdateSubscription dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateSubscription Was Called");
                    Log.Information("UpdateSubscription Was Returned");
                    await _subscription.UpdateOrDeleteSubscription(dto);
                    return StatusCode(201, "Subscription Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates UserSubscription In My Db
        /// </summary>
        /// <response code="200">Returns UserSubscription Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("UpdateUserSubscription")]
        public async Task<IActionResult> UpdateUserSubscription([FromBody] UpdateUserSubscriptions dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateUserSubscription Was Called");
                    Log.Information("UpdateUserSubscription Was Returned");
                    await _userSubscription.UpdateOrDeleteUserSubscriptions(dto);
                    return StatusCode(201, "User Subscription Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Resets Password
        /// </summary>
        /// <response code="200">ResetPassword Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("ResetPassword Was Called");
                    Log.Information("ResetPassword Was Returned");
                    await _user.ResetPassword(dto);
                    return StatusCode(201, "Admin Has Been Updated");
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
