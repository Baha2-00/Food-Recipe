﻿using Food_Recipe_Core.DTOs.Subscription;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface ISubscriptionRepos
    {
        Task<UpdateSubscription> GetSubscriptionDetails(int id);

        Task<List<GetAllSubscription>> GetAllSubscriptions();

        Task CreateSubscription(Subscription createSubscriptionDto);

        Task UpdateOrDeleteSubscription(Subscription updateSubscriptionDto);
    }
}