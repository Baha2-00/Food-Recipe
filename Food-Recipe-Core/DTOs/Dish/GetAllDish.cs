using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.DTOs.Dish
{
    public class GetAllDish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CategoryId { get; set; }
        public int? CuisineId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
