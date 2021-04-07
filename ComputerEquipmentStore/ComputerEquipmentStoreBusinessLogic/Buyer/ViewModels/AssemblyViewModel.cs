using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class AssemblyViewModel
    {
        public int Id { get; set; }

        [DisplayName("ID покупателя")]
        public int BuyerId { get; set; }

        [DisplayName("Название сборки")]
        public string AssemblyName { get; set; }

        [DisplayName("Cтоимость")]
        public decimal Cost { get; set; }

        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
