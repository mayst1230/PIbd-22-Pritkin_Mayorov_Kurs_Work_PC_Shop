using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Enums;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.BusinessLogics
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;

        public OrderLogic(IOrderStorage orderStorage)
        {
            this._orderStorage = orderStorage;
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
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                ProductId = model.ProductId,
                Count = model.Count,
                DateOrder = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel 
            { OrderName = model.OrderName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Заказ уже существует");
            }
            if (model.Id.HasValue)
            {
                _orderStorage.Update(model);
            }
            else
            {
                _orderStorage.Insert(model);
            }
        }

        public void Delete(OrderBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrderBindingModel 
            { Id = model.Id 
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _orderStorage.Delete(model);
        }
    }
}