using System;
using System.Collections.Generic;
using System.Text;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.HelperModels
{
    class ExcelInfoBuyer
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportPurchaseComponentsViewModel> PurchaseComponents { get; set; }
    }
}
