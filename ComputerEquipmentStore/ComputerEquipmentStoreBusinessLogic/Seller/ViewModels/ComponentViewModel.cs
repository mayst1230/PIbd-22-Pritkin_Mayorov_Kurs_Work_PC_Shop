using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        [DisplayName("Комплектующее")]
        public string ComponentName { get; set; }
    }
}
