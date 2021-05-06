using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int? Id { get; set; }
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int Count { get; set; }

    }
}
