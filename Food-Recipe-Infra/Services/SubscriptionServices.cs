using Food_Recipe_Core.DTOs.Subscription;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
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


        public Task CreateSubscription(CreateSubscription createSubscriptionDto)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
