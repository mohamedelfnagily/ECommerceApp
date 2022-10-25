using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Models
{
    public class CartProduct
    {
        [ForeignKey("product")]
        public Guid productId { get; set; }
        public Product product { get; set; }
        [ForeignKey("cart")]
        public Guid CartId { get; set; }
        public Cart cart { get; set; }
        public int NumberOfItems { get; set; }
    }
}
