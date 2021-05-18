using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Сборка
    /// </summary>
    public class AssemblyBindingModel
    {
        /// <summary>
        /// ID сборки
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// Название сборки
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Стоимость сборки
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Комплектующие находящиеся в этой сборке <ID \компонента (Название компонента, количество, цена)>
        /// </summary>
        public Dictionary<int, (string, int, decimal)> Components { get; set; }      
    }
}
