using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.UserSubscriptions
{
    public class UpdateUserSubscriptions
    {
        public int ID { get; set; }
        public double? Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? UserId { get; set; }
        public int? SubscriptionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
