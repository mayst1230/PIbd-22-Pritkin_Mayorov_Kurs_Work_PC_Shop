using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        [DisplayName("ID покупателя")]
        public int BuyerId { get; set; }

        [DisplayName("Название покупки")]
        public string PurchaseName { get; set; }

        [DisplayName("Общая стоимость")]
        public decimal TotalCost { get; set; }

        [DisplayName("Дата покупки")]
        public DateTime DatePurchase { get; set; }

        public Dictionary<int, (string, int, decimal)> Assemblies { get; set; }

        public Dictionary<int, (string, int, decimal)> Products { get; set; }
    }
}
