using System;
using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime DatePurchase { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
