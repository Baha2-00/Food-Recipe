using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Users;
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
    public class UserRepos : IUserRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public UserRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public Task CreateUser(User createUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllUser>> GetAllUsers()
        {
            var query = from user in _RecipeDbContext.Users
                        select new GetAllUser
                        {
                         Id = user.Id,
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         Role=user.Role,
                         ProfileImage = user.ProfileImage
                        };
            return await query.ToListAsync();
        }

        public Task<GetUserDetailsDTO> GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrDeleteUser(User updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
