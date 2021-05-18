using System;
using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.HelperModels
{
    class PdfInfoBuyer
    {

        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<ReportPurchasesViewModel> InfoAboutPurchases { get; set; }

        public int? BuyerId { get; set; }
    }
}
