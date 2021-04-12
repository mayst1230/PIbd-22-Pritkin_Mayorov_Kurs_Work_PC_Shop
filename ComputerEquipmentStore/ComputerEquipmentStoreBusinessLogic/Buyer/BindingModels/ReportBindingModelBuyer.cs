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
        //Название отчета
        public string FileName { get; set; }

        //Начальная дата периода
        public DateTime? DateFrom { get; set; }

        //Конечная дата периода
        public DateTime? DateTo { get; set; }

        //Покупки по которым будет производиться отчет
        public List<PurchaseViewModel> Purchases { get; set; }
    }
}
