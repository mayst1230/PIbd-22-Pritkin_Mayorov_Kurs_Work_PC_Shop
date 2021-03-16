using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Seller.Interfaces
{
    public interface IProductStorage
    {
        List<ProductViewModel> GetFullList();
        List<ProductViewModel> GetFilteredList(ProductBindingModel modelProduct);
        ProductBindingModel GetElement(ProductBindingModel modelProduct);
        void Insert(ProductBindingModel modelProduct);
        void Update(ProductBindingModel modelProduct);
        void Delete(ProductBindingModel modelProduct);
    }
}
