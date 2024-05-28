using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Helper.ENUM
{
    public class ENUMs
    {
        public enum Role
        {
            Admin,
            Client
        }
        public enum SocicalMedia
        {
            Instagram,
            Facebook,
            X,
            Youtube
        }
        public enum PaymentMethod
        {
            CliQ,
            Visa
        }
        public enum SubscriptionPeriod
        {
            Monthly,
            Annual,
            Days_14
        }
        public enum QuantityUnit
        {
            TeaSpoon,
            TableSpoon,
            Cup,
            Gram,
            Liter
        }
        public enum Priority
        {
            High,
            Medium,
            Low
        }
    }
}
