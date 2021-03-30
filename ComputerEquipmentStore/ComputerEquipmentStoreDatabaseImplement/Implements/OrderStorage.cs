using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using ComputerEquipmentStoreDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStoreEquipmentDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Order order = context.Orders.Include(rec => rec.Seller)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    OrderName = order.OrderName,
                    DateOrder = order.DateOrder,
                    Status = order.Status,
                    Count = order.Count,
                    SellerId = order.SellerId,
                    ProductId = order.ProductId
                } :
                null;
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Orders.Include(rec => rec.Seller).
                Where(rec => rec.OrderName.Contains(model.OrderName)).
                Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    OrderName = rec.OrderName,
                    DateOrder = rec.DateOrder,
                    Status = rec.Status,
                    Count = rec.Count,
                    SellerId = rec.SellerId,
                    ProductId = rec.ProductId
                }).ToList();
            }
        }

        public List<OrderViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Orders.Include(rec => rec.Seller).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    OrderName = rec.OrderName,
                    DateOrder = rec.DateOrder,
                    Status = rec.Status,
                    Count = rec.Count,
                    SellerId = rec.SellerId,
                    ProductId = rec.ProductId
                }).ToList();
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Заказ на товар не найден");
                }
                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ на товар не найден");
                }
            }
        }

        public Order CreateModel(OrderBindingModel model, Order order)
        {
            order.OrderName = model.OrderName;
            order.DateOrder = model.DateOrder;
            order.Status = model.Status;
            order.Count = model.Count;
            order.SellerId = model.SellerId;
            order.ProductId = model.ProductId;
            return order;
        }
    }
}
