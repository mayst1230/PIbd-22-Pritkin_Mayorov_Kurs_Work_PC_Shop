using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int SellerId { get; set; }

        [DisplayName("Название товара")]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
