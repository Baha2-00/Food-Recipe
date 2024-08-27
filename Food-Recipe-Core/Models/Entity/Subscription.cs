using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.Models.Entity
{
    public class Subscription : MainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AllowdDishesRecipce { get; set; }
        public string AllowedRequest { get; set; }
        public double Price { get; set; }
        public SubscriptionPeriod subscriptionPeriod { get; set; }
    }
}
