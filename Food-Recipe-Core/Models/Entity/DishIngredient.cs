using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.Entity
{
    public class DishIngredient : MainEntity
    {
        public int? DishId { get; set; }
        public int? IngredientId { get; set; }
    }
}
