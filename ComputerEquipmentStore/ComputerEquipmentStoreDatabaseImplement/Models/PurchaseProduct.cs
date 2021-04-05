using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class PurchaseProduct
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Product Product { get; set; }
    }
}
