using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.Entity
{
    public class DishPreparingSteps : MainEntity
    {
        public string serial { get; set; }
        public string Title { get; set; }
    }
}
