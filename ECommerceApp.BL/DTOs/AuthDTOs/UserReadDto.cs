using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.DTOs.AuthDTOs
{
    public class UserReadDto
    {
        public string Token { get; set; }
        public int ExpiryDuration { get; set; }

    }
}
