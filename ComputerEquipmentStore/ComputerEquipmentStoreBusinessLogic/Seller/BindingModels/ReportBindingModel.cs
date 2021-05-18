using System;
using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public int? SellerId { get; set; }
    }
}
