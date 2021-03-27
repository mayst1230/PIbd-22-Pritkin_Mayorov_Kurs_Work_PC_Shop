using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class SellerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Никнейм")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
