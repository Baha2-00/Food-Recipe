using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
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


        public Task CreateUser(CreateUser createUserDto)
        {
            throw new NotImplementedException();
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
