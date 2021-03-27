using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BindingModels
{
    public class SellerBindingModel
    {
        public int? Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
