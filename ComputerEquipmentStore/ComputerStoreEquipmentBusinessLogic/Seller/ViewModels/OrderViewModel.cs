using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [DisplayName("Название товара")]
        public string ProductName { get; set; }
        /// <summary>
        /// продумать что будет еще
        /// </summary>
        [DisplayName("Дата создания заказа")]
        public DateTime DateOrder { get; set; }
    }
}
