using System;
using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.HelperModels
{
    class WordInfoBuyer
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportPurchaseComponentsViewModel> PurchaseComponents { get; set; }
    }
}
