﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.DTOs.DishPreparingSteps
{
    public class GetAllDishPreparingSteps
    {
        public int Id { get; set; }
        public int serial { get; set; }
        public string Title { get; set; }
        public string desc { get; set; }
        public string? attachment { get; set; }
    }
}
