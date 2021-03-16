using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Комплектующее")]
        public string ComponentName { get; set; }
        /// <summary>
        /// У комплектующих словарь товаров
        /// </summary>
        public Dictionary<int, (string, int)> Products { get; set; }
    }
}
