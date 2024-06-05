using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface IUserRepos
    {
        Task<GetUserDetailsDTO> GetUserDetails(int id);

        Task<List<GetAllUser>> GetAllUsers();

        Task CreateUser(User createUserDto);

        Task UpdateOrDeleteUser(UpdateUser updateUserDto);
    }
}
