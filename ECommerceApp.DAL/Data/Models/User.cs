using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Models
{
    public class User:IdentityUser
    {
        [Required]
        [StringLength(20, ErrorMessage = "Maximum length 20 characters")]
        public string FirstName { get; set; } = "";
        [Required]
        [StringLength(20, ErrorMessage = "Maximum length 20 characters")]
        public string LastName { get; set; } = "";
        public byte[]? Image { get; set; }

    }
}
