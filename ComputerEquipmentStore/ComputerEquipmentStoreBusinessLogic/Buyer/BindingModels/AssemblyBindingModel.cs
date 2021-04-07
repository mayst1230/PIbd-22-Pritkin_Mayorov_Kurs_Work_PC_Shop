using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Сборка
    /// </summary>
    public class AssemblyBindingModel
    {
        //ID сборки
        public int? Id { get; set; }

        public int BuyerId { get; set; }

        public string AssemblyName { get; set; }

        //Общая стоимость сборки
        public decimal Cost { get; set; }

        //Комплектующие находящиеся в этой сборке
        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
