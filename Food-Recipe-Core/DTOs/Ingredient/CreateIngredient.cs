﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.DTOs.Ingredient
{
    public class CreateIngredient
    {
        public string    Name { get; set; }
        public string    Description { get; set; }
        public string    Title { get; set; }
        public string    Image { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
