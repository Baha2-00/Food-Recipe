using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.DTOs.Dish
{
    public class GetAllDishDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string? IngredientName { get; set; }
        public string? Quantity { get; set; }

        // Dish preparing steps  
        public string? preparingStepsDescription { get; set; }
        public bool IsDeleted { get; set; }
    }
}
