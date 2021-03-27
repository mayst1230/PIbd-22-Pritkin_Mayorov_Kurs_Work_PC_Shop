using System;

namespace ComputerEquipmentStoreBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string OrderName { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
