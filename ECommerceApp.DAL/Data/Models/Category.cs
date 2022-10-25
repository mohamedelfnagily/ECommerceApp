using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Models
{
    public class Category
    {
        public Category()
        {
            products = new HashSet<Product>();
        }
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(250, ErrorMessage = "Maximum 250 characters")]
        public string Description { get; set; } = "";
        public virtual ICollection<Product> products { get; set; }
    }
}
