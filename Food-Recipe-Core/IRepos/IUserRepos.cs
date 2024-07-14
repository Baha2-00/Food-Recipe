using Food_Recipe_Core.DTOs.Login;
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
        Task<User> GetUserById(int id);
        Task<int> GetUserIdAfterLoginOperation(string email, string password);
        Task<GetUserDetailsDTO> GetUserDetails(int id);
        Task<List<GetAllUser>> GetAllUsers();
        Task<int> CreateAdmin(User createAdminDto);
        Task<int> CreateUser(User createUserDto);
        Task UpdateOrDeleteUser(UpdateUser updateUserDto);
        Task ResetPassword(ResetPassDTO dto);
        Task LoginToWebsite(LoginEntryDTO dt);
    }
}
