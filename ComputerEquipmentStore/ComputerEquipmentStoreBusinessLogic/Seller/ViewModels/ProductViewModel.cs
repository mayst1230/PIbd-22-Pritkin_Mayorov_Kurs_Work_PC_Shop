using System.ComponentModel;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int SellerId { get; set; }

        [DisplayName("Название товара")]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, string> Components { get; set; }
    }
}
