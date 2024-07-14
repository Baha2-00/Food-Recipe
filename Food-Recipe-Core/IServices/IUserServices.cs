using Food_Recipe_Core.DTOs.Authentication;
using Food_Recipe_Core.DTOs.Login;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IServices
{
    public interface IUserServices
    {
        Task<string> GenerateUserAccessToken(AuthenticationDTO input);
        Task<User> TryAuthanticate(AuthenticationDTO input);
        Task<GetUserDetailsDTO> GetUserProfile(int id);

        Task<List<GetAllUser>> GetAllUsers();
        Task CreateAdmin(CreateRegisterDTO createRegisterDto);

        Task CreateUser(CreateRegisterDTO createRegisterDto);

        Task UpdateUser(UpdateUser updateUserDto);
        Task UpdateUserActivation(int id , bool value);
        Task ResetPassword(ResetPassDTO dto);
        Task LoginToWebsite(LoginEntryDTO dt);
    }
}
