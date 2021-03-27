using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    public class BuyerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Логин покупателя")]
        public string Login { get; set; }

        [DisplayName("Пароль покупателя")]
        public string Password { get; set; }
    }
}
