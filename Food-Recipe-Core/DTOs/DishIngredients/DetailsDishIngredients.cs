﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.DishIngredients
{
    public class DetailsDishIngredients
    {
        public int Id { get; set; }
        public string? DishName { get; set; }
        public string? IngredientName { get; set; }
        public int? Quantity { get; set; }
        public string? quantityUnit { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
