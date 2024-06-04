using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class UserSubscriptionServices : IUserSubscriptionServices
    {
        public Task CreateUserSubscriptions(CreateUserSubscriptions createUserSubscriptionsDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllUserSubscriptions>> GetAllUserSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateAndDetailsUserSubscriptions> GetUserSubscriptionsDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteUserSubscriptions(UpdateAndDetailsUserSubscriptions updateUserSubscriptionsDto)
        {
            throw new NotImplementedException();
        }
    }
}
