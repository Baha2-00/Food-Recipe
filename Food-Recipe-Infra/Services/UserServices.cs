using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepos _userRepos;
        public UserServices(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }


        public async Task CreateUser(CreateUserDTO createUserDto)
        {
            User user = new User()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Phone = createUserDto.Phone,
                BirthDate = createUserDto.BirthDate,
                CreationDate = createUserDto.CreationDate,
                Role =createUserDto.Role
            };
            //move to repos
            int entityId = await _userRepos.CreateUser(user);
        }

        public async Task<List<GetAllUser>> GetAllUsers()
        {
            return await _userRepos.GetAllUsers();
        }

        public async Task<GetUserDetailsDTO> GetUserProfile(int id)
        {
            return await _userRepos.GetUserDetails(id);
        }

        public Task UpdateOrDeleteUser(UpdateUser updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
