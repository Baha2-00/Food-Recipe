using Food_Recipe_Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Infra.Repos.DbInjection
{
    public class InjectDBfood
    {
        private readonly FoodRecipeDBContext _Recipe;
        public InjectDBfood(FoodRecipeDBContext Recipe)
        {
            _Recipe = Recipe;
        }
    }
}
