using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
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
        public async Task<int> CreateUser(User createUserDto)
        {
            _RecipeDbContext.Users.Add(createUserDto);
            await _RecipeDbContext.SaveChangesAsync();
            return createUserDto.Id;
        }

        public async Task<List<GetAllUser>> GetAllUsers()
        {
            var query = from user in _RecipeDbContext.Users
                        select new GetAllUser
                        {
                         Id = user.Id,
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         Role=user.Role.ToString(),
                         ProfileImage = user.ProfileImage
                        };
            return await query.ToListAsync();
        }

        public async Task<GetUserDetailsDTO> GetUserDetails(int id)
        {
            var result = await _RecipeDbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (result != null)
            {
                GetUserDetailsDTO response = new GetUserDetailsDTO()
                {
                    Id = result.Id,
                    FirstName= result.FirstName,
                    LastName= result.LastName,
                    Email= result.Email,
                    Phone= result.Phone,
                    BirthDate= result.BirthDate,
                    Role= result.Role.ToString(),
                    ProfileImage = result.ProfileImage,
                    SocicalMediaAccount=result.SocicalMediaAccount.ToString(),
                    CreationDate= result.CreationDate,
                    IsDeleted= result.IsDeleted

                };
                return response;
            }
            throw new Exception("not found");
        }

        public Task UpdateOrDeleteUser(UpdateUser updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
