using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.BusinessLogics
{
    public class OrderLogic
    {
       /* private readonly IOrderStorage _orderStorage;
        public OrderLogic(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ComponentBindingModel model)
        {
            var element = _componentStorage.GetElement(new ComponentBindingModel
            {
                ComponentName = model.ComponentName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _componentStorage.Update(model);
            }
            else
            {
                _componentStorage.Insert(model);
            }
        }
        public void Delete(ComponentBindingModel model)
        {
            var element = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Комплектующее не найдено");
            }
            _componentStorage.Delete(model);
        }*/

        ///добавить метод добавления товара к заказу
    }
}
