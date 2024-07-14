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

        public async Task UpdateSubscription(UpdateSubscription updateSubscriptionDto)
        {
            var query = await _subscriptionRepos.GetSubscriptionByID(updateSubscriptionDto.Id);

            if (query != null)
            {
                query.Title = updateSubscriptionDto.Title;
                query.Description = updateSubscriptionDto.Description;
                query.AllowdDishesRecipce = updateSubscriptionDto.AllowdDishesRecipce;
                query.AllowedRequest = updateSubscriptionDto.AllowedRequest;
                query.Price = updateSubscriptionDto.Price;
                query.subscription = updateSubscriptionDto.subscription;

                await _subscriptionRepos.UpdateOrDeleteSubscription(query);
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }

        public async Task UpdateSubscriptionActivation(int id, bool value)
        {
            var query = await _subscriptionRepos.GetSubscriptionByID(id);
            if (query != null)
            {
                query.IsDeleted= value;
                await _subscriptionRepos.UpdateOrDeleteSubscription(query);
            }
            else
            {
                throw new Exception("Subscription Does not Exisit");
            }
        }
    }
}
