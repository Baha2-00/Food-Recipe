using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.DishRequest
{
    public class ViewDishRequests
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Purpose { get; set; }
        public DateTime RequestDate { get; set; }
        public string? Priority { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? UserId { get; set; }
    }
}
