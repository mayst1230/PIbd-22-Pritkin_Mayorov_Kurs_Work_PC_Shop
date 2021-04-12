using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class BuyerViewModel
    {
        /// <summary>
        /// ID покупателя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин покупателя
        /// </summary>
        [DisplayName("Логин покупателя")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль покупателя
        /// </summary>
        [DisplayName("Пароль покупателя")]
        public string Password { get; set; }
    }
}
