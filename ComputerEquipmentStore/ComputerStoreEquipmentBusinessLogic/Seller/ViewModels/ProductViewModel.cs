using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ProductViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название товара")]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
        /// <summary>
        /// У товаров словарь комплектующих
        /// </summary>
        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
