using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Id продавца")]
        public int SellerId { get; set; }

        [DisplayName("Название товара")]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int, decimal)> Components { get; set; }
    }
}
