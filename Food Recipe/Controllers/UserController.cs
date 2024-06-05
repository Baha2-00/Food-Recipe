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
         ICategoryServices category, ICuisineServices cuisine, IDishServices dish
            , IIngredientServices ingredient, IDishPreparingStepsServices preparingSteps
            , IDishIngredientsServices dishIngredients, ISubscriptionServices subscription,
            IUserSubscriptionServices userSubscription, ILoginServices login , IDishRequestServices dishRequest)
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
    }
}
