﻿using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IUserSubscriptionRepos
    {
        Task<UserSubscription> GetUserSubscriptionByID(int id);
        Task<DetailsUserSubscriptions> GetUserSubscriptionsDetails(int id);

        Task<List<GetAllUserSubscriptions>> GetAllUserSubscriptions();

        Task CreateUserSubscriptions(UserSubscription createUserSubscriptionsDto);

        Task UpdateUserSubscriptions<T>(T inp);
    }
}
