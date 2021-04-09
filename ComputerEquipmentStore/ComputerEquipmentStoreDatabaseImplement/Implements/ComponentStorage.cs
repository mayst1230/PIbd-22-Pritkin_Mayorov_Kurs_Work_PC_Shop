using Microsoft.EntityFrameworkCore;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using ComputerEquipmentStoreDatabaseImplement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStoreEquipmentDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Component component = context.Components.Include(rec => rec.Seller)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return component != null ?
                new ComponentViewModel
                {
                    Id = component.Id,
                    ComponentName = component.ComponentName,
                    Price = component.Price,
                    SellerId = component.SellerId
                } :
                null;
            }
        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Components.Include(rec => rec.Seller)
                    .Where(rec => rec.ComponentName.Contains(model.ComponentName))
                    .Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName,
                    Price = rec.Price,
                    SellerId = rec.SellerId
                }).ToList();
            }
        }

        public List<ComponentViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Components.Include(rec => rec.Seller).Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName,
                    Price = rec.Price,
                    SellerId = rec.SellerId
                }).ToList();
            }
        }

        public void Insert(ComponentBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Components.Add(CreateModel(model, new Component()));
                context.SaveChanges();
            }
        }

        public void Update(ComponentBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Component component = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (component == null)
                {
                    throw new Exception("Комплектующее не найдено");
                }
                CreateModel(model, component);
                context.SaveChanges();
            }
        }

        public void Delete(ComponentBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Component component = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (component != null)
                {
                    context.Components.Remove(component);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Комплектующее не найдено");
                }
            }
        }

        public Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.ComponentName;
            component.Price = model.Price;
            component.SellerId = model.SellerId;
            return component;
        }
    }
}