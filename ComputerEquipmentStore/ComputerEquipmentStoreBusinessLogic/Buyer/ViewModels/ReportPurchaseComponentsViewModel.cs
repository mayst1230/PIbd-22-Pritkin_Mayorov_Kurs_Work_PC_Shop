using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    /// <summary>
    /// отчет по комплектующим по выбранным покупкам
    /// </summary>
    public class ReportPurchaseComponentsViewModel
    {
        /// <summary>
        /// Название покупки
        /// </summary>
        public string PurchaseName { get; set; }
       
        /// <summary>
        /// Общая стоимость
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Список компонентов
        /// </summary>
        public List<Tuple<string, int>> Components { get; set; }
    }
}
