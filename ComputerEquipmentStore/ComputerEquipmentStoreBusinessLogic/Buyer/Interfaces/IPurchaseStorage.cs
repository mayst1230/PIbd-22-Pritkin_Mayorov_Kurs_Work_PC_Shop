using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    public interface IPurchaseStorage
    {
        List<PurchaseViewModel> GetFullList();

        List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model);

        PurchaseViewModel GetElement(PurchaseBindingModel model);

        void Insert(PurchaseBindingModel model);
        void Update(PurchaseBindingModel model);
        void Delete(PurchaseBindingModel model);
    }
}
