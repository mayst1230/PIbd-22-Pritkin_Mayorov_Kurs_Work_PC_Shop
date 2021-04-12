using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    /// <summary>
    /// Покупка
    /// </summary>
    public class PurchaseViewModel
    {
        /// <summary>
        /// ID покупки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        [DisplayName("ID покупателя")]
        public int BuyerId { get; set; }

        /// <summary>
        /// Название покупки
        /// </summary>
        [DisplayName("Название покупки")]
        public string PurchaseName { get; set; }

        /// <summary>
        /// Общая стоимость
        /// </summary>
        [DisplayName("Общая стоимость")]
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Дата покупки
        /// </summary>
        [DisplayName("Дата покупки")]
        public DateTime DatePurchase { get; set; }

        /// <summary>
        /// Сборки этой покупки
        /// </summary>
        public Dictionary<int, (string, int, decimal)> Assemblies { get; set; }

        /// <summary>
        /// Товары этой покупки
        /// </summary>
        public Dictionary<int, (string, int, decimal)> Products { get; set; }
    }
}
