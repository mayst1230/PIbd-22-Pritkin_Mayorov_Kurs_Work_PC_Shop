using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class ReportPurchaseComponentsViewModel
    {
        //Название покупки
        public string PurchaseName { get; set; }
       
        //Общая стоимость
        public int TotalCount { get; set; }

        //Список компонентов
        public List<Tuple<string, int>> Components { get; set; }
    }
}
