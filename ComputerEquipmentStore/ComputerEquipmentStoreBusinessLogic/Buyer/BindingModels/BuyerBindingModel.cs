using System;
using System.Collections.Generic;
using System.Text;

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

        //Покупки покупателя
        public Dictionary<int, (string, int)> Purchases { get; set; }
    }
}
