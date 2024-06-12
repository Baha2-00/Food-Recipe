﻿using Food_Recipe_Core.Context;
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

        public async Task LoginToWebsite(LoginEntryDTO dt)
        {
            if (string.IsNullOrEmpty(dt.UserName) || string.IsNullOrEmpty(dt.Password))
                throw new Exception("Email Or Phone and Password are required");
            var login = await _RecipeDbContext.Logins
                 .Where(x => (x.UserName.Equals(dt.UserName) || x.Password.Equals(dt.Password)))
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

        public async Task UpdateOrDeleteUser(UpdateUser dto)
        {
            var query = await _RecipeDbContext.Users.FindAsync(dto.Id);

            if (query != null)
            {
                query.FirstName = dto.FirstName;
                query.LastName = dto.LastName;
                query.Phone = dto.Phone;
                query.ProfileImage = dto.ProfileImage;
                query.IsDeleted= dto.IsDeleted;
                query.SocicalMediaAccount = dto.SocicalMediaAccount;
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
