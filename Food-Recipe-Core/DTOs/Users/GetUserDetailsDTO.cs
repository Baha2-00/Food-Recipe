﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Food_Recipe_Core.Helper.ENUM.ENUMs;

namespace Food_Recipe_Core.DTOs.Users
{
    public class GetUserDetailsDTO
    {
        public int    Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
        public string? ProfileImage { get; set; }
        public string? SocicalMediaAccount { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
