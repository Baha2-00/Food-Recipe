using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.DTOs.DishPreparingSteps
{
    public class DishPreparingStepsDetailsDTO
    {
        public int Id { get; set; }
        public int serial { get; set; }
        public string Title { get; set; }
        public string desc { get; set; }
        public string? attachment { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DishId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
