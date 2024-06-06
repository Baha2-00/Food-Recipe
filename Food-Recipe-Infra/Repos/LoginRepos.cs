using Food_Recipe_Core.Context;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos
{
    public class LoginRepos : ILoginRepos
    {
        private readonly FoodRecipeDBContext _RecipeDbContext;
        public LoginRepos(FoodRecipeDBContext Recipe)
        {
            _RecipeDbContext = Recipe;
        }
        public async Task CreateLogin(Login createLoginDto)
        {
            _RecipeDbContext.Logins.Add(createLoginDto);
            await _RecipeDbContext.SaveChangesAsync();
        }
    }
}
