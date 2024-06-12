using Food_Recipe_Core.DTOs.Login;
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
    public class LoginServices : ILoginServices
    {
        //private readonly ILoginRepos _login;
        //public LoginServices(ILoginRepos login)
        //{
        //    _login = login;
        //}
        //public async Task CreateLogin(CreateLogin createLoginDto)
        //{

        //    Login login = new Login()
        //    {
        //        UserName = createLoginDto.UserName,
        //        Password = createLoginDto.Password,
        //        UserId = createLoginDto.Userid
        //    };
        //    await _login.CreateLogin(login);
        //}
    }
}
