using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int Count { get; set; }

    }
}
