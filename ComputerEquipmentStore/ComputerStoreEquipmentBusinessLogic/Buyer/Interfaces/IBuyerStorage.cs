using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    public interface IBuyerStorage
    {
        List<BuyerViewModel> GetFullList();

        List<BuyerViewModel> GetFilteredList(BuyerBindingModel model);

        BuyerViewModel GetElement(BuyerBindingModel model);

        void Insert(BuyerBindingModel model);
        void Update(BuyerBindingModel model);
        void Delete(BuyerBindingModel model);
    }
}
