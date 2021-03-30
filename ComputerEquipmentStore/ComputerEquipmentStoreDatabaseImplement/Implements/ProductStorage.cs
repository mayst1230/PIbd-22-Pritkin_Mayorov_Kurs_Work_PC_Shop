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
    public class ProductStorage : IProductStorage
    {
        public Product CreateModel(ProductBindingModel model, Product product, ComputerEquipmentStoreDatabase context)
        {
            product.ProductName = model.ProductName;
            product.SellerId = model.SellerId;
            product.Price = model.Price;
            if (product.Id == 0)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                List<ProductComponent> productComponents = context.ProductComponents.Where(rec => rec.ProductId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ProductComponents.RemoveRange(productComponents.Where(rec => !model.Components.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
            }
            // добавили новые
            foreach (KeyValuePair<int, string> CSP in model.Components)
            {
                context.ProductComponents.Add(new ProductComponent
                {
                    ProductId = product.Id,
                    ComponentId = CSP.Key
                });
                context.SaveChanges();
            }
            return product;
        }

        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var product = context.Products.Include(rec => rec.ProductComponents)
                    .ThenInclude(rec => rec.Component)
                    .Include(rec => rec.Seller)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.ProductName == model.ProductName);
                return product != null ?
                new ProductViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    SellerId = product.SellerId,
                    Price = product.Price,
                    Components = product.ProductComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => recCSP.Component?.ComponentName)
                } :
                null;
            }
        }

        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Products.Include(rec => rec.ProductComponents)
                    .ThenInclude(rec => rec.Component)
                    .Include(rec => rec.Seller)
                    .Where(rec => rec.ProductName.Contains(model.ProductName))
                    .ToList()
                    .Select(rec => new ProductViewModel
                    {
                        Id = rec.Id,
                        ProductName = rec.ProductName,
                        SellerId = rec.SellerId,
                        Price = rec.Price,
                        Components = rec.ProductComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => recCSP.Component?.ComponentName)
                    }).ToList();
            }
        }

        public List<ProductViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Products.Include(rec => rec.ProductComponents)
                    .ThenInclude(rec => rec.Component)
                    .Include(rec => rec.Seller)
                    .ToList()
                    .Select(rec => new ProductViewModel
                    {
                        Id = rec.Id,
                        ProductName = rec.ProductName,
                        SellerId = rec.SellerId,
                        Price = rec.Price,
                        Components = rec.ProductComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => recCSP.Component?.ComponentName)
                    }).ToList();
            }
        }

        public void Insert(ProductBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Product(), context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(ProductBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Products.FirstOrDefault(rec => rec.Id == model.Id || rec.ProductName == model.ProductName);
                        if (element == null)
                        {
                            throw new Exception("Товар не найден");
                        }
                        CreateModel(model, element, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(ProductBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var element = context.Products.FirstOrDefault(rec => rec.Id == model.Id || rec.ProductName == model.ProductName);
                if (element != null)
                {
                    context.Products.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Товар не найден");
                }
            }
        }
    }
}