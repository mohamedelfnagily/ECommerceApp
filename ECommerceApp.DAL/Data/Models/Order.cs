using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public bool IsDelivered { get; set; }
        public int OrderTotal { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; } = "";
        [Required]
        public string City { get; set; } = "";
        [Required]
        public int ZipCode { get; set; }
        [Required]
        [RegularExpression("^[0125][0-9]{8}$", ErrorMessage = "Egyptian numbers only")]
        public string MobileNumber { get; set; } = "";
        [ForeignKey("Cart")]
        public Guid cartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
