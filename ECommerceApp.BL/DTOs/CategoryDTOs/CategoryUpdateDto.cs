using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.DTOs.CategoryDTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(250, ErrorMessage = "Maximum 250 characters")]
        public string Description { get; set; } = "";
    }
}
