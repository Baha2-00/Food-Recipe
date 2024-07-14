using Food_Recipe_Core.DTOs.UserSubscriptions;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food_Recipe_Infra.Services
{
    public class UserSubscriptionServices : IUserSubscriptionServices
    {
        private readonly IUserSubscriptionRepos _userSubRepos;
        public UserSubscriptionServices(IUserSubscriptionRepos userSubRepos)
        {
            _userSubRepos = userSubRepos;
        }

        public async Task ChangeUserSubActivation(int id, bool value)
        {
            var Usersub = await _userSubRepos.GetUserSubscriptionByID(id);
            if (Usersub != null)
            {
                Usersub.IsDeleted = value;
                await _userSubRepos.UpdateUserSubscriptions(Usersub);
            }
            else
            {
                throw new Exception("User Subscription Does not Exist");
            }
        }

        public async Task CreateUserSubscriptions(CreateUserSubscriptions createUserSubscriptionsDto)
        {
            UserSubscription userSubscription = new UserSubscription()
            {
                Amount = createUserSubscriptionsDto.Amount,
                PaymentMethod = createUserSubscriptionsDto.PaymentMethod,
                IssueDate= createUserSubscriptionsDto.IssueDate,
                UserId = createUserSubscriptionsDto.UserId,
                SubscriptionId = createUserSubscriptionsDto.SubscriptionId,
                CreationDate = createUserSubscriptionsDto.CreationDate
            };
            await _userSubRepos.CreateUserSubscriptions(userSubscription);
        }

        public async Task<List<GetAllUserSubscriptions>> GetAllUserSubscriptions()
        {
            return await _userSubRepos.GetAllUserSubscriptions();
        }

        public async Task<DetailsUserSubscriptions> GetUserSubscriptionsDetails(int id)
        {
            return await _userSubRepos.GetUserSubscriptionsDetails(id);
        }

        public async Task UpdateUserSubscriptions(UpdateUserSubscriptions updateUserSubscriptionsDto)
        {
            var query = await _userSubRepos.GetUserSubscriptionByID(updateUserSubscriptionsDto.ID);

            if (query != null)
            {
                query.Amount = updateUserSubscriptionsDto.Amount;
                query.PaymentMethod = updateUserSubscriptionsDto.PaymentMethod;
                query.IssueDate = updateUserSubscriptionsDto.IssueDate;
                query.UserId = updateUserSubscriptionsDto.UserId;
                query.SubscriptionId = updateUserSubscriptionsDto.SubscriptionId;


                await _userSubRepos.UpdateUserSubscriptions(query);
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }
    }
}
