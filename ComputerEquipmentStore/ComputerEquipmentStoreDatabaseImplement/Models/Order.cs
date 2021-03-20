using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }
        public virtual Product Product { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
