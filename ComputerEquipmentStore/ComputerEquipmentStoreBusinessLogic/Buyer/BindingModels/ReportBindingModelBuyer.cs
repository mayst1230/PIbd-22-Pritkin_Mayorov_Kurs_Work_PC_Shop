using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Отчет
    /// </summary>
    public class ReportBindingModelBuyer
    {
        /// <summary>
        /// Название отчета
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Начальная дата периода
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Конечная дата периода
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Покупки по которым будет производиться отчет
        /// </summary>
        public List<PurchaseViewModel> Purchases { get; set; }
    }
}
