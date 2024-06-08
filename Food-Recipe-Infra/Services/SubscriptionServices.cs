using Food_Recipe_Core.DTOs.Subscription;
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
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly ISubscriptionRepos _subscriptionRepos;
        public SubscriptionServices(ISubscriptionRepos subscriptionRepos)
        {
            _subscriptionRepos = subscriptionRepos;
        }


        public async Task CreateSubscription(CreateSubscription createSubscriptionDto)
        {
            Subscription subscription = new Subscription()
            {
                Title = createSubscriptionDto.Title,
                Description = createSubscriptionDto.Description,
                AllowdDishesRecipce=createSubscriptionDto.AllowdDishesRecipce,
                AllowedRequest=createSubscriptionDto.AllowedRequest,
                Price=createSubscriptionDto.Price,
                subscription=createSubscriptionDto.subscription,
                CreationDate=createSubscriptionDto.CreationDate
            };
            await _subscriptionRepos.CreateSubscription(subscription);
        }

        public async Task<List<GetAllSubscription>> GetAllSubscriptions()
        {
            return await _subscriptionRepos.GetAllSubscriptions();
        }

        public Task<GetSubscriptionDetailsDTO> GetSubscriptionDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteSubscription(UpdateSubscription updateSubscriptionDto)
        {
            return _subscriptionRepos.UpdateOrDeleteSubscription(updateSubscriptionDto);
        }
    }
}
