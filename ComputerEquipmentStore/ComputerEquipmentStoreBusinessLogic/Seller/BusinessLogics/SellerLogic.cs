using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics
{
    public class SellerLogic
    {
        private readonly ISellerStorage _sellerStorage;
        public SellerLogic(ISellerStorage sellerStorage)
        {
            _sellerStorage = sellerStorage;
        }
        public List<SellerViewModel> Read(SellerBindingModel model)
        {
            if (model == null)
            {
                return _sellerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SellerViewModel> { _sellerStorage.GetElement(model) };
            }
            return _sellerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(SellerBindingModel model)
        {
            var element = _sellerStorage.GetElement(new SellerBindingModel
            {
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть продавец с таким никнеймом");
            }
            if (model.Id.HasValue)
            {
                _sellerStorage.Update(model);
            }
            else
            {
                _sellerStorage.Insert(model);
            }
        }
        public void Delete(SellerBindingModel model)
        {
            var element = _sellerStorage.GetElement(new SellerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Продавец не найден");
            }
            _sellerStorage.Delete(model);
        }
    }
}