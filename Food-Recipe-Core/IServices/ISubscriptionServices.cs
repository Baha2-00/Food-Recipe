using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface ISubscriptionServices
    {
        Task<GetSubscriptionDetailsDTO> GetSubscriptionDetails(int id);

        Task<List<GetAllSubscription>> GetAllSubscriptions();

        Task CreateSubscription(CreateSubscription createSubscriptionDto);

        Task UpdateSubscription(UpdateSubscription updateSubscriptionDto);
        Task UpdateSubscriptionActivation(int id , bool value);
    }
}
