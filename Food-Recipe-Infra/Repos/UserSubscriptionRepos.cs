using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Cuisine;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class UserSubscriptionRepos : IUserSubscriptionRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public UserSubscriptionRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateUserSubscriptions(UserSubscription createUserSubscriptionsDto)
        {
            _RecipeDbContext.UserSubscriptions.Add(createUserSubscriptionsDto);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllUserSubscriptions>> GetAllUserSubscriptions()
        {
            var query = from user in _RecipeDbContext.UserSubscriptions
                        select new GetAllUserSubscriptions
                        {
                           ID=user.Id,
                           Amount=user.Amount,
                           PaymentMethod=user.PaymentMethod.ToString(),
                           IssueDate=user.IssueDate,
                           CreationDate=user.CreationDate,
                        };
            return await query.ToListAsync();
        }

        public async Task<UpdateAndDetailsUserSubscriptions> GetUserSubscriptionsDetails(int id)
        {
            var result = await _RecipeDbContext.UserSubscriptions.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                UpdateAndDetailsUserSubscriptions response = new UpdateAndDetailsUserSubscriptions()
                {
                    ID=result.Id,
                    Amount=result.Amount,
                    PaymentMethod=result.PaymentMethod.ToString(),
                    IssueDate=result.IssueDate,
                    UserId=result.UserId,
                    SubscriptionId=result.SubscriptionId,
                    CreationDate = result.CreationDate,
                    IsDeleted = result.IsDeleted
                };
                return response;
            }
            throw new Exception("not found");
        }

        public Task UpdateOrDeleteUserSubscriptions(UpdateAndDetailsUserSubscriptions updateUserSubscriptionsDto)
        {
            throw new NotImplementedException();
        }
    }
}
