using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class UserSubscriptionRepos : IUserSubscriptionRepos
    {
        public Task CreateUserSubscriptions(UserSubscription createUserSubscriptionsDto)
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

        public Task UpdateOrDeleteUserSubscriptions(UserSubscription updateUserSubscriptionsDto)
        {
            throw new NotImplementedException();
        }
    }
}
