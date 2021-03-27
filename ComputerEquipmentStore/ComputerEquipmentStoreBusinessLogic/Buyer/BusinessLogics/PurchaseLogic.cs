using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    public class PurchaseLogic
    {
        private readonly IPurchaseStorage _purchaseStorage;
        public PurchaseLogic(IPurchaseStorage purchaseStorage)
        {
            this._purchaseStorage = purchaseStorage;
        }
        public List<PurchaseViewModel> Read(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return _purchaseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchaseViewModel>
                {
                    _purchaseStorage.GetElement(model)
                };
            }
            return _purchaseStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PurchaseBindingModel model)
        {
            var element = _purchaseStorage.GetElement(new PurchaseBindingModel
            {
                PurchaseName = model.PurchaseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть покупка с таким названием");
            }
            if (model.Id.HasValue)
            {
                _purchaseStorage.Update(model);
            }
            else
            {
                _purchaseStorage.Insert(model);
            }
        }
        public void Delete(PurchaseBindingModel model)
        {
            var element = _purchaseStorage.GetElement(new PurchaseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупка не найдена");
            }
            _purchaseStorage.Delete(model);
        }
    }
}
