using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Seller.Interfaces
{
    public interface IProductStorage
    {
        List<ProductViewModel> GetFullList();
        List<ProductViewModel> GetFilteredList(ProductBindingModel model);
        ProductViewModel GetElement(ProductBindingModel model);
        void Insert(ProductBindingModel model);
        void Update(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
