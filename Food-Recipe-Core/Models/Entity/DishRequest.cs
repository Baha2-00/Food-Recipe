using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.Entity
{
    public class DishRequest : MainEntity
    {
        public string Title { get; set; }
        public string Purpose { get; set; }
        public DateTime RequestDate { get; set; }
        public string Priority { get; set; }
        public int? UserId { get; set; }
    }
}
