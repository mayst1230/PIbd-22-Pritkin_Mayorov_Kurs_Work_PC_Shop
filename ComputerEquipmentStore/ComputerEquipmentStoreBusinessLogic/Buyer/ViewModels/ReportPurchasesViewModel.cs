using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class ReportPurchasesViewModel
    {

        public DateTime DatePurchase { get; set; }

        //Название покупки
        public string PurchaseName { get; set; }

        public int Count { get; set; }

        //Список компонентов (Название, Количество)
        public List<Tuple<string, int>> Components { get; set; }
        
        //Список компонентов (Текст комментария, Дата)
        public List<Tuple<string, DateTime>> Comments { get; set; }
    }
}
