using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateOrder { get; set; }

        //продумать нужны ли будут внешние ключи? - ID продавца и ID товара
    }
}
