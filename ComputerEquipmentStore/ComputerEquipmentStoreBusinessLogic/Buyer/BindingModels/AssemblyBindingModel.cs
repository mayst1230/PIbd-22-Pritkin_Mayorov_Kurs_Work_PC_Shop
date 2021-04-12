using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Сборка
    /// </summary>
    public class AssemblyBindingModel
    {
        //ID сборки
        public int? Id { get; set; }

        //ID покупателя
        public int BuyerId { get; set; }

        //Название сборки
        public string AssemblyName { get; set; }

        //Стоимость сборки
        public decimal Cost { get; set; }

        //Комплектующие находящиеся в этой сборке <ID компонента (Название компонента, количество, цена)>
        public Dictionary<int, (string, int, decimal)> Components { get; set; }
    }
}
