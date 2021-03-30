using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }
        public int SellerId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ComponentName { get; set; }
        public Seller Seller { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<ProductComponent> ProductComponents { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<AssemblyComponent> AssemblyComponents { get; set; }
    }
}
