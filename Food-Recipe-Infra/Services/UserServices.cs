using Food_Recipe_Core.DTOs.Authentication;
using Food_Recipe_Core.DTOs.Login;
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
        private readonly ILoginRepos _loginRepos;
        public UserServices(IUserRepos userRepos , ILoginRepos loginRepos)
        {
            _userRepos = userRepos;
            _loginRepos = loginRepos;
        }

        public async Task CreateAdmin(CreateRegisterDTO createRegisterDto)
        {
            User Admin = new User()
            {
                FirstName = createRegisterDto.FirstName,
                LastName = createRegisterDto.LastName,
                Email = createRegisterDto.Email,
                Phone = createRegisterDto.Phone,
                BirthDate = createRegisterDto.BirthDate,
                Role = (Food_Recipe_Core.Helper.ENUM.ENUMs.Role)1,
                CreationDate = DateTime.Now
            };
            //move to repos
            int entityId = await _userRepos.CreateAdmin(Admin);

            Login login = new Login()
            {
                UserName = createRegisterDto.Email,
                Password = createRegisterDto.Password,
                UserId = entityId
            };
            //move to repos
            await _loginRepos.CreateLogin(login);
        }

        public async Task CreateUser(CreateRegisterDTO createRegisterDto)
        {
            User user = new User()
            {
                FirstName = createRegisterDto.FirstName,
                LastName = createRegisterDto.LastName,
                Email = createRegisterDto.Email,
                Phone = createRegisterDto.Phone,
                BirthDate = createRegisterDto.BirthDate,
                Role = (Food_Recipe_Core.Helper.ENUM.ENUMs.Role)2,
                CreationDate=DateTime.Now
            };
            //move to repos
            int entityId = await _userRepos.CreateUser(user);

            Login login = new Login()
            {
                UserName = createRegisterDto.Email,
                Password = createRegisterDto.Password,
                UserId = entityId
            };
            //move to repos
            await _loginRepos.CreateLogin(login);
        }

        public async Task<List<GetAllUser>> GetAllUsers()
        {
            return await _userRepos.GetAllUsers();
        }

        public async Task<GetUserDetailsDTO> GetUserProfile(int id)
        {
            return await _userRepos.GetUserDetails(id);
        }

        public async Task LoginToWebsite(LoginEntryDTO dt)
        {
            await _userRepos.LoginToWebsite(dt);
        }
        public async Task ResetPassword(ResetPassDTO dto)
        {
            await _userRepos.ResetPassword(dto);
        }

        public Task UpdateOrDeleteUser(UpdateUser updateUserDto)
        {
            return _userRepos.UpdateOrDeleteUser(updateUserDto);
        }
    }
}
