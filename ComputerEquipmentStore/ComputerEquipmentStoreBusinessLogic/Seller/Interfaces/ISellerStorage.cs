using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Seller.Interfaces
{
    public interface ISellerStorage
    {
        List<SellerViewModel> GetFullList();
        List<SellerViewModel> GetFilteredList(SellerBindingModel model);
        SellerViewModel GetElement(SellerBindingModel model);
        void Insert(SellerBindingModel model);
        void Update(SellerBindingModel model);
        void Delete(SellerBindingModel model);
    }
}
