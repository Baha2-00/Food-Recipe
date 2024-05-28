using Food_Recipe_Core.DTOs.Login;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.IRepos
{
    public interface ILoginRepos
    {
        Task CreateLogin(Login createLoginDto);
    }
}
