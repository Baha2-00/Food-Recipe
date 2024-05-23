using Food_Recipe_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.Entity
{
    public class UserSubscription : MainEntity
    {
        public int? UserId { get; set; }
        public int? SubscriptionId { get; set; }
    }
}
