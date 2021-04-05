using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.HelperModels
{
    class ListAssemblyInfoStorekeeper
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public Dictionary<int, ReportAssemblyProductViewModel> AssemblyProduct{ get; set; }
    }
}
