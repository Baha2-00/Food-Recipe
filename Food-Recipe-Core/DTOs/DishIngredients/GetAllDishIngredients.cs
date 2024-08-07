﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.DishIngredients
{
    public class GetAllDishIngredients
    {
        public int ID { get; set; }
        public int DishId { get; set; }
        public int? IngredientId { get; set; }
        public int? Quantity { get; set; }
        public string? quantityUnit { get; set; }
    }
}
