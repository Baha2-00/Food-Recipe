using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class UserSubscriptionServices : IUserSubscriptionServices
    {
        private readonly IUserSubscriptionRepos _userSubRepos;
        public UserSubscriptionServices(IUserSubscriptionRepos userSubRepos)
        {
            _userSubRepos = userSubRepos;
        }
        public async Task CreateUserSubscriptions(CreateUserSubscriptions createUserSubscriptionsDto)
        {
            UserSubscription userSubscription = new UserSubscription()
            {
                Amount = createUserSubscriptionsDto.Amount,
                PaymentMethod = createUserSubscriptionsDto.PaymentMethod,
                IssueDate= createUserSubscriptionsDto.IssueDate,
                UserId = createUserSubscriptionsDto.UserId,
                SubscriptionId = createUserSubscriptionsDto.SubscriptionId,
                CreationDate = createUserSubscriptionsDto.CreationDate
            };
            await _userSubRepos.CreateUserSubscriptions(userSubscription);
        }

        public async Task<List<GetAllUserSubscriptions>> GetAllUserSubscriptions()
        {
            return await _userSubRepos.GetAllUserSubscriptions();
        }

        public async Task<UpdateAndDetailsUserSubscriptions> GetUserSubscriptionsDetails(int id)
        {
            return await _userSubRepos.GetUserSubscriptionsDetails(id);
        }

        public Task UpdateOrDeleteUserSubscriptions(UpdateAndDetailsUserSubscriptions updateUserSubscriptionsDto)
        {
            throw new NotImplementedException();
        }
    }
}
