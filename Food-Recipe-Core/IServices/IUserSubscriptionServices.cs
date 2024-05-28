using Food_Recipe_Core.DTOs.Dish;
using Food_Recipe_Core.DTOs.UserSubscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IUserSubscriptionServices
    {
        Task<UpdateAndDetailsUserSubscriptions> GetUserSubscriptionsDetails(int id);

        Task<List<GetAllUserSubscriptions>> GetAllUserSubscriptions();

        Task CreateUserSubscriptions(CreateUserSubscriptions createUserSubscriptionsDto);

        Task UpdateOrDeleteUserSubscriptions(UpdateAndDetailsUserSubscriptions updateUserSubscriptionsDto);
    }
}
