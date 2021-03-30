using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("ID продавца")]
        public int SellerId { get; set; }

        [DisplayName("Комплектующее")]
        public string ComponentName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
