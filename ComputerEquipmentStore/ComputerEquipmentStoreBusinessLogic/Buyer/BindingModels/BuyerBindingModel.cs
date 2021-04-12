
namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public class BuyerBindingModel
    {
        //ID покупателя
        public int? Id { get; set; }

        //Логин покупателя
        public string Login { get; set; }

        //Пароль покупателя
        public string Password { get; set; }
    }
}
