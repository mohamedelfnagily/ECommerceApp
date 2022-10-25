using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Models
{
    public class Product
    {
        public Product()
        {
            cartProduct = new HashSet<CartProduct>();
        }
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum length 20 characters")]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(250, ErrorMessage = "Maximum length 20 characters")]
        public string Description { get; set; } = "";
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        [Required]
        public int Price { get; set; }
        public bool OnSale { get; set; }
        [Range(1, 5)]
        public int? Rating { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<CartProduct> cartProduct { get; set; }
        public int UnitInStock { get; set; }
    }
}
