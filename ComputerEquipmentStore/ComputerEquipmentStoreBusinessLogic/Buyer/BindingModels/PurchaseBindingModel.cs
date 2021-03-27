using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Покупка
    /// </summary>
    public class PurchaseBindingModel
    {

        //ID покупки
        public int? Id { get; set; }

        public int BuyerId { get; set; }

        public string PurchaseName { get; set; }

        //Общая стоимость покупки
        public int TotalCost { get; set; }

        //Дата покупки
        public DateTime DatePurchase { get; set; }

        //Сборки находящиеся в этой покупке
        public Dictionary<int, (string, int)> Assemblies { get; set; }

        //Товары находящиеся в этой покупке
        public Dictionary<int, (string, int)> Products { get; set; }

    }
}
