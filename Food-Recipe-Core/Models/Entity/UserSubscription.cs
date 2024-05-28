using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.Models.Entity
{
    public class UserSubscription : MainEntity
    {
        public double? Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? UserId { get; set; }
        public int? SubscriptionId { get; set; }
    }
}
