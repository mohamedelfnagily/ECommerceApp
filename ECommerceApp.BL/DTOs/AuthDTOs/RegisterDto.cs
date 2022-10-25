﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.DTOs.AuthDTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string MobileNumber { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
