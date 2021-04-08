using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;

namespace ComputerEquipmentStoreBusinessLogic.HelperModels
{
    public class ListAssemblyInfoStorekeeper
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportAssemblyProductViewModel> AssemblyProduct{ get; set; }
    }
}
