using System;
using System.ComponentModel;
using ComputerEquipmentStoreBusinessLogic.Seller.Enums;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }

        [DisplayName("Название заказа")]
        public string OrderName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DisplayName("Дата создания заказа")]
        public DateTime DateOrder { get; set; }
    }
}
