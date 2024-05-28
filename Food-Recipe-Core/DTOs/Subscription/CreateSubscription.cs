using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.Subscription
{
    public class CreateSubscription
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AllowdDishesRecipce { get; set; }
        public string AllowedRequest { get; set; }
        public double Price { get; set; }
        public SubscriptionPeriod subscription { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
