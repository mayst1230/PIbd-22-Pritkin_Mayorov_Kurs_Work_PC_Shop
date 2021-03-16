using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.BusinessLogics
{
    public class ProductLogic
    {
        /*private readonly IProductStorage _travelStorage;
        public TravelLogic(IProductStorage travelStorage)
        {
            _travelStorage = travelStorage;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return _travelStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _travelStorage.GetElement(model) };
            }
            return _travelStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            var element = _travelStorage.GetElement(new ProductBindingModel
            {
                TravelName = model.TravelName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть товар с таким названием");
            }
            if (model.Id.HasValue)
            {
                _travelStorage.Update(model);
            }
            else
            {
                _travelStorage.Insert(model);
            }
        }
        public void Delete(ProductBindingModel model)
        {
            var element = _travelStorage.GetElement(new ProductBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Товар не найден");
            }
            _travelStorage.Delete(model);
        }*/
    }
}
