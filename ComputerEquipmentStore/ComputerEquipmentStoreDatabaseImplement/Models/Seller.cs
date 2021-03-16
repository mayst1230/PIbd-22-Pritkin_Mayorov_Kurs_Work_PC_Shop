using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
   public class Seller
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("SellerId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("SellerId")]
        public virtual List<Product> Products { get; set; }

        [ForeignKey("SellerId")]
        public virtual List<Component> Components { get; set; }
    }
}
