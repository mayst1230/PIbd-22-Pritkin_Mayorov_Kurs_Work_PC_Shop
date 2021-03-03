using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Общая стоимость")]
        public int TotalCost { get; set; }

        [DisplayName("Дата покупки")]
        public DateTime DatePurchase { get; set; }

        public Dictionary<int, (string, int)> Assemblies { get; set; }

        public Dictionary<int, (string, int)> Products { get; set; }
    }
}
