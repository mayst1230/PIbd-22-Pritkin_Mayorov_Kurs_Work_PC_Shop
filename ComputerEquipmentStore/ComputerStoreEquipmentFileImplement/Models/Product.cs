using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string NameProduct { get; set; }

        [ForeignKey("SellerId")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("SellerId")]
        public virtual List<Product> Products { get; set; }
    }
}
