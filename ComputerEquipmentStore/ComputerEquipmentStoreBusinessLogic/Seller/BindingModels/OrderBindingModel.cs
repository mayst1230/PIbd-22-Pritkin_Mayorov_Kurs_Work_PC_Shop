using System;
using ComputerEquipmentStoreBusinessLogic.Seller.Enums;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int Count { get; set; }
        public OrderStatus Status { get; set; }
        public string OrderName { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
