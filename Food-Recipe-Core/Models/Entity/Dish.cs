using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.Entity
{
    public class Dish : MainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int? CategoryId { get; set; }
        public int? CuisineId { get; set; }
        public int? UserId { get; set; }
        public bool? IsApproved {  get; set; }

        // Ingredient properties
        public string? IngredientName { get; set; }
        public string? Quantity { get; set; }

        // Dish preparing steps  
        public string? preparingStepsDescription { get; set; }
    }
}
