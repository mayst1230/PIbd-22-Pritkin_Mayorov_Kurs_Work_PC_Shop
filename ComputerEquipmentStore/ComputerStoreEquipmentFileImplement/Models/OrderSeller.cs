using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class OrderSeller
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SellerId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
