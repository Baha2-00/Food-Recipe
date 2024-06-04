using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.DishIngredients
{
    public class DetailsDishIngredients
    {
        public int Id { get; set; }
        public int? DishId { get; set; }
        public int? IngredientId { get; set; }
        public int? Quantity { get; set; }
        public QuantityUnit? quantityUnit { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
