using Food_Recipe_Core.DTOs.Authentication;
using Food_Recipe_Core.DTOs.Login;
using Food_Recipe_Core.DTOs.Users;
using Food_Recipe_Core.Helper.Security_Token;
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
        public async Task UpdateUser(UpdateUser updateUserDto)
        {
            var query = await _userRepos.GetUserById(updateUserDto.Id);

            if (query != null)
            {
                query.FirstName = updateUserDto.FirstName;
                query.LastName = updateUserDto.LastName;
                query.Phone = updateUserDto.Phone;
                query.ProfileImage = updateUserDto.ProfileImage;
                query.SocicalMediaAccount = updateUserDto.SocicalMediaAccount;

                await _userRepos.UpdateOrDeleteUser(query);
            }
            else
            {
                throw new Exception($"Content not found");
            }
        }
        public async Task<string> GenerateUserAccessToken(AuthenticationDTO input)
        {
            var user = await TryAuthanticate(input);
            if (user != null)
            {
                return TokenHelper.GenerateJwtToken(user);
            }
            throw new Exception("Failed To Generate Token");

        }
        public async Task<User> TryAuthanticate(AuthenticationDTO input)
        {
            var userId = await _userRepos.GetUserIdAfterLoginOperation(input.UserName, input.Password);
            if (userId != 0)
            {
                return await _userRepos.GetUserById(userId);
            }
            else
            {
                throw new Exception("Wrong Email / Password");
            }
        }

        public async Task UpdateUserActivation(int id, bool value)
        {
            var User = await _userRepos.GetUserById(id);
            if (User != null)
            {
                User.IsDeleted = value;
                await _userRepos.UpdateOrDeleteUser(User);
            }
            else
            {
                throw new Exception("User Does not Exist");
            }
        }
    }
}
