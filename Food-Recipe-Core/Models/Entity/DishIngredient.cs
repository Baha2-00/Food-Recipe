using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.Models.Entity
{
    public class DishIngredient : MainEntity
    {
        public int? DishId { get; set; }
        public int? IngredientId { get; set; }
        public int? Quantity { get; set; }
        public QuantityUnit? quantityUnit { get; set; }
    }
}
