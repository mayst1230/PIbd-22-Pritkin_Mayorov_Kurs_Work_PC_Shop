namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class BuyerBindingModel
    {
        /// <summary>
        /// ID покупателя
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Логин покупателя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль покупателя
        /// </summary>
        public string Password { get; set; }
    }
}
