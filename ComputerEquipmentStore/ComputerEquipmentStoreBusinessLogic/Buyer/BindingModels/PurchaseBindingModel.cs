using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Покупка
    /// </summary>
    public class PurchaseBindingModel
    {

        //ID покупки
        public int? Id { get; set; }

        //ID покупателя
        public int BuyerId { get; set; }

        //Название покупки
        public string PurchaseName { get; set; }

        //Общая стоимость покупки
        public decimal TotalCost { get; set; }

        //Дата покупки
        public DateTime DatePurchase { get; set; }

        //Начальная дата периода (нужно для отчета)
        public DateTime? DateFrom { get; set; }

        //Конечная дата периода (нужно для отчета)
        public DateTime? DateTo { get; set; }

        //Сборки находящиеся в этой покупке
        public Dictionary<int, (string, int, decimal)> Assemblies { get; set; }

        //Товары находящиеся в этой покупке
        public Dictionary<int, (string, int, decimal)> Products { get; set; }

    }
}
