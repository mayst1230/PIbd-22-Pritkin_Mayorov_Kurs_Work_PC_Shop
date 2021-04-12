using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    /// <summary>
    /// Сборка
    /// </summary>
    public class AssemblyViewModel
    {
        /// <summary>
        /// ID сборки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        [DisplayName("ID покупателя")]
        public int BuyerId { get; set; }

        /// <summary>
        /// Название сборки
        /// </summary>
        [DisplayName("Название сборки")]
        public string AssemblyName { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [DisplayName("Cтоимость")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Комплектующие этой сборки
        /// </summary>
        public Dictionary<int, (string, int, decimal)> Components { get; set; }
    }
}
