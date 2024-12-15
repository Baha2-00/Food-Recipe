using Food_Recipe_Core.Context;
using Food_Recipe_Core.DTOs.Category;
using Food_Recipe_Core.DTOs.Login;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Food_Recipe_Infra.Repos
{
    public class UserRepos : IUserRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public UserRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }

        public async Task<int> CreateAdmin(User createAdminDto)
        {
            _RecipeDbContext.Users.Add(createAdminDto);
            await _RecipeDbContext.SaveChangesAsync();
            return createAdminDto.Id;
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
                         Email=user.Email,
                         Phone= user.Phone,
                         Role=user.Role.ToString(),
                         CreationDate = user.CreationDate.ToString(),
                         IsDeleted = user.IsDeleted
                        };
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _RecipeDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
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
                    ProfileImage = $"https://localhost:44332/Images/{result.ProfileImage}",
                    SocicalMediaAccount=result.SocicalMediaAccount,
                    CreationDate= result.CreationDate,
                    IsDeleted= result.IsDeleted

                };
                return response;
            }
            throw new Exception("not found");
        }

        public async Task<int> GetUserIdAfterLoginOperation(string email, string password)
        {
            var query = from Login in _RecipeDbContext.Logins
                        where Login.UserName == email
                        && Login.Password == password
                        select Login.UserId;
            return await query.SingleOrDefaultAsync();
        }

        public async Task LoginToWebsite(LoginEntryDTO dt)
        {
            if (string.IsNullOrEmpty(dt.UserName) || string.IsNullOrEmpty(dt.Password))
                throw new Exception("Email Or Phone and Password are required");
            var login = await _RecipeDbContext.Logins
                 .Where(x => (x.UserName.Equals(dt.UserName) && x.Password.Equals(dt.Password)))
                 .SingleOrDefaultAsync();
            if (login == null)
            {
                throw new Exception("Email Or Password Is Not Correct");
            }
        }

        public async Task ResetPassword(ResetPassDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email is required");
            var user = await _RecipeDbContext.Logins.Where(x => x.UserName.Equals(dto.Email)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                if (string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.ConfirmPassword))
                    throw new Exception("Password and ConfirmPassword are required");
                else
                {
                    if (dto.Password.Equals(dto.ConfirmPassword))
                    {
                        user.Password = dto.ConfirmPassword;
                        _RecipeDbContext.Update(user);
                        await _RecipeDbContext.SaveChangesAsync();
                    }
                }

            }
        }

        public async Task UpdateOrDeleteUser<T>(T input)
        {
                _RecipeDbContext.Update(input);
                await _RecipeDbContext.SaveChangesAsync();
        }
    }
}
