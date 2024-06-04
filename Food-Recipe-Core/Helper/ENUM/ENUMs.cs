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
            Admin=1,
            Client=2
        }
        public enum SocicalMedia
        {
            Instagram=1,
            Facebook=2,
            X=3,
            Youtube=4
        }
        public enum PaymentMethod
        {
            CliQ = 1,
            Visa = 2
        }
        public enum SubscriptionPeriod
        {
            Monthly = 1,
            Annual = 2,
            Days_14 = 3
        }
        public enum QuantityUnit
        {
            TeaSpoon = 1,
            TableSpoon = 2,
            Cup =3,
            Gram =4,
            Liter=5
        }
        public enum Priority
        {
            High=1,
            Medium=2,
            Low=3
        }
    }
}
