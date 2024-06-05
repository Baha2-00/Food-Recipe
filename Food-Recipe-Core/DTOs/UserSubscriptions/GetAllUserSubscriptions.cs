﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.UserSubscriptions
{
    public class GetAllUserSubscriptions
    {
        public int ID { get; set; }
        public double? Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime CreationDate { get; set; } 
    }
}
