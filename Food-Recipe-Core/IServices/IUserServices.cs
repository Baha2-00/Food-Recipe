using Food_Recipe_Core.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IUserServices
    {
        Task<GetUserDetailsDTO> GetUserProfile(int id);

        Task<List<GetAllUser>> GetAllUsers();

        Task CreateUser(CreateUser createUserDto);

        Task UpdateOrDeleteUser(UpdateUser updateUserDto);
    }
}
