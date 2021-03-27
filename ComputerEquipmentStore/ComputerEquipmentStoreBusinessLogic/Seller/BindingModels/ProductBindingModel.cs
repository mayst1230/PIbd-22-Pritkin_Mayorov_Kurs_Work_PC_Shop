using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.BindingModels
{
    public class ProductBindingModel
    {
        public int? Id { get; set; }
        public int SellerId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
