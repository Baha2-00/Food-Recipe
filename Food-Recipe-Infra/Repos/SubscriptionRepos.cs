using Food_Recipe_Core.DTOs.Subscription;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class SubscriptionRepos : ISubscriptionRepos
    {
        public Task CreateSubscription(Subscription createSubscriptionDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllSubscription>> GetAllSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task<GetSubscriptionDetailsDTO> GetSubscriptionDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteSubscription(Subscription updateSubscriptionDto)
        {
            throw new NotImplementedException();
        }
    }
}
