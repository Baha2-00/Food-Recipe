using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.DishIngredients;
using Food_Recipe_Core.DTOs.DishPreparingSteps;
using Food_Recipe_Core.DTOs.DishRequest;
using Food_Recipe_Core.DTOs.Ingredient;
using Food_Recipe_Core.DTOs.Login;
using Food_Recipe_Core.DTOs.Subscription;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IServices;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Food_Recipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
        private readonly IDishRequestServices _DishRequest;

        public UserController(IUserServices service,
         ICategoryServices category, ICuisineServices cuisine, IDishServices dish,
         IIngredientServices ingredient, IDishPreparingStepsServices preparingSteps,
         IDishIngredientsServices dishIngredients, ISubscriptionServices subscription,
         IUserSubscriptionServices userSubscription, ILoginServices login ,
         IDishRequestServices dishRequest)
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
            _DishRequest = dishRequest;
        }

        #region Get

        /// <summary>
        /// Retrieves One Dish Request In My Db
        /// </summary>
        /// <response code="200">Returns the available Dish Request</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetDishRequestByid([FromRoute] int id)
        {
            try
            {
                Log.Information("GetDishRequestByid Was Called");
                Log.Information("GetDishRequestByid Was Returned");
                return StatusCode(200, await _DishRequest.ViewDishRequest(id));
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
        /// Logs You To website
        /// </summary>
        /// <response code="200">Returns login Is done</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("LoginToSite")]
        public async Task<IActionResult> LoginToSite([FromBody] LoginEntryDTO dt)
        {
            if (dt == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("loginEntry Was Called");
                    Log.Information("loginEntry Was Returned");
                    await _user.LoginToWebsite(dt);
                    return StatusCode(201, "Login is Done");
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
        /// Creates A New Ingredients In My Db
        /// </summary>
        /// <response code="200">Returns A New Ingredients Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewIngredients")]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredient createIngredienthDto)
        {
            if (createIngredienthDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateIngredient Was Called");
                    Log.Information("CreateIngredient Was Returned");
                    await _ingredient.CreateIngredients(createIngredienthDto);
                    return StatusCode(201, "New Ingredients have Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New DishIngredients In My Db
        /// </summary>
        /// <response code="200">Returns A New DishIngredients Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewDishIngredients")]
        public async Task<IActionResult> CreateDishIngredients([FromBody] CreateDishIngredients createDishIngredientsDto)
        {
            if (createDishIngredientsDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateDishIngredients Was Called");
                    Log.Information("CreateDishIngredients Was Returned");
                    await _DishIngredients.CreateDishIngredient(createDishIngredientsDto);
                    return StatusCode(201, "New Ingredients have Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New DishRequest In My Db
        /// </summary>
        /// <response code="200">Returns A New DishRequest Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateDishRequest")]
        public async Task<IActionResult> CreateDishRequest([FromBody] CreateDishRequest createDishRequestDto)
        {
            if (createDishRequestDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateDishRequest Was Called");
                    Log.Information("CreateDishRequest Was Returned");
                    await _DishRequest.CreateDishRequests(createDishRequestDto);
                    return StatusCode(201, "New DishRequest have Been Send");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates A New DishPreparingSteps In My Db
        /// </summary>
        /// <response code="200">Returns A New DishPreparingSteps Is Created</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPost]
        [Route("CreateNewDishPreparingSteps")]
        public async Task<IActionResult> CreateDishPreparingSteps([FromBody] CreateDishPreparingSteps createDishPreparingStepsDto)
        {
            if (createDishPreparingStepsDto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("CreateDishPreparingSteps Was Called");
                    Log.Information("CreateDishPreparingSteps Was Returned");
                    await _preparingSteps.CreateDishPreparingSteps(createDishPreparingStepsDto);
                    return StatusCode(201, "New Dish Preparing Steps have Been Created");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        #endregion


        #region Update And Delete

        /// <summary>
        /// Updates One Dish In My Db
        /// </summary>
        /// <response code="200">Returns Dish Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDish([FromBody] UpdateDishDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateDish Was Called");
                    Log.Information("UpdateDish Was Returned");
                    await _dish.UpdateDish(dto);
                    return StatusCode(201, "Dish Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// UpdateDishActivation In My Db
        /// </summary>
        /// <response code="200">Returns UpdateDishActivation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDishActivation([FromQuery] int id, [FromQuery] bool value)
        {
            if (id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateDishActivation Was Called");
                    Log.Information("UpdateDishActivation Was Returned");
                    await _dish.UpdateDishActivation(id,value);
                    return StatusCode(201, "DishActivation Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates One Ingredient In My Db
        /// </summary>
        /// <response code="200">Returns Ingredient Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredients dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateIngredient Was Called");
                    Log.Information("UpdateIngredient Was Returned");
                    await _ingredient.UpdateIngredients(dto);
                    return StatusCode(201, "Ingredient Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// UpdateIngredientActivation In My Db
        /// </summary>
        /// <response code="200">Returns UpdateIngredientActivation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateIngredientActivation([FromQuery] int id , [FromQuery] bool value)
        {
            if (id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateIngredientActivation Was Called");
                    Log.Information("UpdateIngredientActivation Was Returned");
                    await _ingredient.UpdateIngredientActivation(id , value);
                    return StatusCode(201, "IngredientActivation Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates One DishIngredient In My Db
        /// </summary>
        /// <response code="200">Returns DishIngredient Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDishIngredients([FromBody] UpdateDishIngredients dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateDishIngredients Was Called");
                    Log.Information("UpdateDishIngredients Was Returned");
                    await _DishIngredients.UpdateDishIngredient(dto);
                    return StatusCode(201, "DishIngredients Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates Dish Ingredient Activation In My Db
        /// </summary>
        /// <response code="200">Returns Dish Ingredient Activation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDishIngredientsActivation([FromQuery] int id, [FromQuery] bool value)
        {
            if (id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateDishIngredients Was Called");
                    Log.Information("UpdateDishIngredients Was Returned");
                    await _DishIngredients.ChangeDishIngredientActivation(id,value);
                    return StatusCode(201, "DishIngredients Activation Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates One DishPreparingSteps In My Db
        /// </summary>
        /// <response code="200">Returns DishPreparingSteps Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDishPreparingSteps([FromBody] UpdateDishPreparingSteps dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateDishPreparingSteps Was Called");
                    Log.Information("UpdateDishPreparingSteps Was Returned");
                    await _preparingSteps.UpdateDishPrepareSteps(dto);
                    return StatusCode(201, "Dish Preparing Steps Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates DishPreparingSteps Activation In My Db
        /// </summary>
        /// <response code="200">Returns DishPreparingSteps Activation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDishPreparingStepsActivation([FromQuery] int id, [FromQuery] bool value)
        {
            if (id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateDishPreparingSteps Activation Was Called");
                    Log.Information("UpdateDishPreparingSteps Activation Was Returned");
                    await _preparingSteps.UpdateDishPrepareStepsActivation(id,value);
                    return StatusCode(201, "Dish Preparing Activation Steps Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates One User In My Db
        /// </summary>
        /// <response code="200">Returns User Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser dto)
        {
            if (dto == null)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateUser Was Called");
                    Log.Information("UpdateUser Was Returned");
                    await _user.UpdateUser(dto);
                    return StatusCode(201, "User Has Been Updated");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        /// <summary>
        /// UpdateUserActivation In My Db
        /// </summary>
        /// <response code="200">Returns UpdateUserActivation Is Updated</response>
        /// <response code="404">Returns If There is no any Matched Object</response>
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUserActivation([FromQuery] int id, [FromQuery] bool value)
        {
            if (id == 0)
            {
                return BadRequest("Please Fill All Data");
            }
            else
            {
                try
                {
                    Log.Information("UpdateUserActivation Was Called");
                    Log.Information("UpdateUserActivation Was Returned");
                    await _user.UpdateUserActivation(id, value);
                    return StatusCode(201, "User Activation Has Been Updated");
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
        /// <response code="200">Reset Password is Done</response>
        /// <response code="404">Returns If There is no any Matched Object</response> 
        /// <response code="500">If there is an error</response>  
        [HttpPut]
        [Route("[action]")]
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
                    return StatusCode(201, "User Password Has Been Updated");
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
