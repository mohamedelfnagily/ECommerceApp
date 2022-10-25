using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            cartProduct = new HashSet<CartProduct>();
        }
        public Guid Id { get; set; }
        public int Size { get; set; }
        public int TotalPrice { get; set; }
        [ForeignKey("user")]
        public string userId { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<CartProduct> cartProduct { get; set; }
    }
}
