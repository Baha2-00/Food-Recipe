using Food_Recipe_Core.DTOs.Subscription;
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
        public Task CreateSubscription(CreateSubscription createSubscriptionDto)
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

        public Task UpdateOrDeleteSubscription(UpdateSubscription updateSubscriptionDto)
        {
            throw new NotImplementedException();
        }
    }
}
