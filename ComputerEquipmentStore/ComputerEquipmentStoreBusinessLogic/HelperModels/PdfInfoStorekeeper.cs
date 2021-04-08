using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.HelperModels
{
    public class PdfInfoStorekeeper
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportComponentsViewModel> ComponentProductAssembly { get; set; }
    }
}
