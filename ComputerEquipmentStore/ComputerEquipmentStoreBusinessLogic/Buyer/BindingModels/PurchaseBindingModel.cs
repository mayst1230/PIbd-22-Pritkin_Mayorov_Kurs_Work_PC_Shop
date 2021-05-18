using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Покупка
    /// </summary>
    public class PurchaseBindingModel
    {
        /// <summary>
        /// ID покупки
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// Название покупки
        /// </summary>
        public string PurchaseName { get; set; }

        /// <summary>
        /// Общая стоимость покупки
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime DatePurchase { get; set; }

        /// <summary>
        /// Начальная дата периода (нужно для отчета)
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Конечная дата периода (нужно для отчета)
        /// </summary>
        public DateTime? DateTo { get; set; }


        /// <summary>
        /// Сборки находящиеся в этой покупке
        /// </summary>
        public Dictionary<int, (string, int, decimal)> Assemblies { get; set; }

        /// <summary>
        /// Товары находящиеся в этой покупке
        /// </summary>
        public Dictionary<int, (string, int, decimal)> Products { get; set; }

        public bool? ReportSeller { get; set; }
    }
}
