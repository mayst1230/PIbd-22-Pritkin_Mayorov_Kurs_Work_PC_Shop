using System;
using System.ComponentModel.DataAnnotations;
using ComputerEquipmentStoreBusinessLogic.Seller.Enums;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string OrderName { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime DateOrder { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
        public virtual Product Product { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
