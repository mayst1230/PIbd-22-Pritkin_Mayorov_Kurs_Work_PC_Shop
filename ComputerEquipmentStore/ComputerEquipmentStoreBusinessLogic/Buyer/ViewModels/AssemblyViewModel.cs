using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class AssemblyViewModel
    {
        public int Id { get; set; }

        [DisplayName("Общая стоимость")]
        public int TotalCost { get; set; }

        public Dictionary<int, (string, int)> Purchases { get; set; }

        public Dictionary<int, (string, int)> AssemblyComments { get; set; }

        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
