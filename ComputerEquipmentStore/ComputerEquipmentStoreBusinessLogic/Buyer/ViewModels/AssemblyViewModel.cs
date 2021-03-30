using System.Collections.Generic;
using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class AssemblyViewModel
    {
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public string AssemblyName { get; set; }

        [DisplayName("Общая стоимость")]
        public int Cost { get; set; }

        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
