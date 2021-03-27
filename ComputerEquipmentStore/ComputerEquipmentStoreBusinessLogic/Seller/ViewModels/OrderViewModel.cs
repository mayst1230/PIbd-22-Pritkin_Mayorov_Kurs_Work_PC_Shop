using System;
using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }

        [DisplayName("Название заказа")]
        public string OrderName { get; set; }
       
        [DisplayName("Дата создания заказа")]
        public DateTime DateOrder { get; set; }
    }
}
