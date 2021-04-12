using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    /// <summary>
    /// Отчет по комплектующим и комментариям за период по покупкам
    /// </summary>
    public class ReportPurchasesViewModel
    {
        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime DatePurchase { get; set; }

        /// <summary>
        /// Название покупки
        /// </summary>
        public string PurchaseName { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Список компонентов (Название, Количество)
        /// </summary>
        public List<Tuple<string, int>> Components { get; set; }

        /// <summary>
        /// Список компонентов (Текст комментария, Дата)
        /// </summary>
        public List<Tuple<string, DateTime>> Comments { get; set; }
    }
}
