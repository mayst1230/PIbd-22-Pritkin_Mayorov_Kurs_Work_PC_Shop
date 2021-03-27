using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    public class BuyerLogic
    {
        private readonly IBuyerStorage _buyerStorage;
        public BuyerLogic(IBuyerStorage buyerStorage)
        {
            _buyerStorage = buyerStorage;
        }
        public List<BuyerViewModel> Read(BuyerBindingModel model)
        {
            if (model == null)
            {
                return _buyerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BuyerViewModel> { _buyerStorage.GetElement(model) };
            }
            return _buyerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(BuyerBindingModel model)
        {
            var element = _buyerStorage.GetElement(new BuyerBindingModel
            {
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть покупатель с таким никнеймом");
            }
            if (model.Id.HasValue)
            {
                _buyerStorage.Update(model);
            }
            else
            {
                _buyerStorage.Insert(model);
            }
        }
        public void Delete(BuyerBindingModel model)
        {
            var element = _buyerStorage.GetElement(new BuyerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупатель не найден");
            }
            _buyerStorage.Delete(model);
        }
    }
}
