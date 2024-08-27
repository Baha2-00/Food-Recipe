﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.DTOs.Cuisine
{
    public class UpdateCuisineDTO
    {
        public int     Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
