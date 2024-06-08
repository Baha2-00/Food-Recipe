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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        /// Retrieves one DishRequest by id In My Db
        /// </summary>
        /// <response code="200">Returns the available users</response>
        /// <response code="500">If there is an error</response>  
        /// 
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetDishRequestByid(int id)
        {
            try
            {
                return StatusCode(200, await _DishRequest.ViewDishRequest(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occurred {ex.Message}");
            }
        }
        #endregion


        #region Create 

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
                    await _dish.CreateDish(createDishDto);
                    return StatusCode(201, "New Dish Has Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

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
                    await _ingredient.CreateIngredients(createIngredienthDto);
                    return StatusCode(201, "New Ingredients have Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

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
                    await _DishIngredients.CreateDishIngredient(createDishIngredientsDto);
                    return StatusCode(201, "New Ingredients have Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }


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
                    await _DishRequest.CreateDishRequests(createDishRequestDto);
                    return StatusCode(201, "New DishRequest have Been Send");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

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
                    await _preparingSteps.CreateDishPreparingSteps(createDishPreparingStepsDto);
                    return StatusCode(201, "New Dish Preparing Steps have Been Created");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }
        #endregion


        #region Update And Delete

        [HttpPut]
        [Route("UpdateDish")]
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
                    await _dish.UpdateOrDeleteDish(dto);
                    return StatusCode(201, "Dish Has Been Updated");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        [HttpPut]
        [Route("UpdateIngredient")]
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
                    await _ingredient.UpdateOrDeleteIngredients(dto);
                    return StatusCode(201, "Ingredient Has Been Updated");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }


        [HttpPut]
        [Route("UpdateDishIngredients")]
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
                    await _DishIngredients.UpdateOrDeleteDishIngredient(dto);
                    return StatusCode(201, "DishIngredients Has Been Updated");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        [HttpPut]
        [Route("UpdateDishPreparingSteps")]
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
                    await _preparingSteps.UpdateOrDeleteDishPrepareSteps(dto);
                    return StatusCode(201, "Dish Preparing Steps Has Been Updated");
                }
                catch (Exception ex)
                {
                    return StatusCode(503, $"Error Orrued {ex.Message}");
                }
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
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
                    await _user.UpdateOrDeleteUser(dto);
                    return StatusCode(201, "User Has Been Updated");
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
