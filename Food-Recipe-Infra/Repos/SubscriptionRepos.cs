﻿using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Subscription;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class SubscriptionRepos : ISubscriptionRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public SubscriptionRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateSubscription(Subscription createSubscriptionDto)
        {
            _RecipeDbContext.Subscriptions.Add(createSubscriptionDto);
            await _RecipeDbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllSubscription>> GetAllSubscriptions()
        {
            var query = from sub in _RecipeDbContext.Subscriptions
                        select new GetAllSubscription
                        {
                            Id= sub.Id,
                            Title= sub.Title,
                            Description= sub.Description,
                            AllowdDishesRecipce= sub.AllowdDishesRecipce,
                            AllowedRequest= sub.AllowedRequest,
                            Price= sub.Price,
                            subscription=sub.subscription.ToString(),
                        };
            return await query.ToListAsync();
        }

        public async Task<Subscription> GetSubscriptionByID(int id)
        {
            return await _RecipeDbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<GetSubscriptionDetailsDTO> GetSubscriptionDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrDeleteSubscription(UpdateSubscription updateSubscriptionDto)
        {
            var query = await _RecipeDbContext.Subscriptions.FindAsync(updateSubscriptionDto.Id);

            if (query != null)
            {
                query.Title = updateSubscriptionDto.Title;
                query.Description = updateSubscriptionDto.Description;
                query.AllowdDishesRecipce = updateSubscriptionDto.AllowdDishesRecipce;
                query.AllowedRequest = updateSubscriptionDto.AllowedRequest;
                query.Price = updateSubscriptionDto.Price;
                query.subscription = updateSubscriptionDto.subscription;
                query.IsDeleted = updateSubscriptionDto.IsDeleted;
                _RecipeDbContext.Update(query);
                await _RecipeDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }
    }
}
