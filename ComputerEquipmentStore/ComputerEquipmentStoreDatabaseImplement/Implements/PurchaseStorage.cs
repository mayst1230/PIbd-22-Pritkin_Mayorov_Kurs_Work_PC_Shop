using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;

namespace ComputerEquipmentStoreDatabaseImplement.Implements
{
    public class PurchaseStorage : IPurchaseStorage
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PurchaseViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Purchases.Include(rec => rec.PurchaseProducts)
                    .ThenInclude(rec => rec.Product)
                    .Include(rec => rec.PurchaseAssemblies)
                    .ThenInclude(rec => rec.Assembly)
                    .Include(rec => rec.Buyer)
                    .ToList()
                    .Select(rec => new PurchaseViewModel
                    {
                        Id = rec.Id,
                        PurchaseName = rec.PurchaseName,
                        BuyerId = rec.BuyerId,
                        TotalCost = rec.TotalCost,
                        DatePurchase = rec.DatePurchase,
                        Products = rec.PurchaseProducts.ToDictionary(recCSP => recCSP.ProductId, recCSP => (recCSP.Product?.ProductName, recCSP.Count, recCSP.Price)),
                        Assemblies = rec.PurchaseAssemblies.ToDictionary(recCSP => recCSP.AssemblyId, recCSP => (recCSP.Assembly?.AssemblyName, recCSP.Count, recCSP.Cost))
                    }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Purchases
                    .Include(rec => rec.Buyer)
                    .Include(rec => rec.PurchaseProducts)
                    .ThenInclude(rec => rec.Product)
                    .Include(rec => rec.PurchaseAssemblies)
                    .ThenInclude(rec => rec.Assembly)
                    .Where(rec => model.BuyerId.HasValue && rec.BuyerId == model.BuyerId || 
                    (rec.DatePurchase >= model.DateFrom && rec.DatePurchase <= model.DateTo && model.BuyerId.HasValue && rec.BuyerId == model.BuyerId)|| 
                    (model.ReportSeller.HasValue && model.ReportSeller.Value && rec.DatePurchase >= model.DateFrom && rec.DatePurchase <= model.DateTo))
                    .ToList()
                    .Select(rec => new PurchaseViewModel
                    {
                        Id = rec.Id,
                        PurchaseName = rec.PurchaseName,
                        BuyerId = rec.BuyerId,
                        TotalCost = rec.TotalCost,
                        DatePurchase = rec.DatePurchase,
                        Products = rec.PurchaseProducts.ToDictionary(recCSP => recCSP.ProductId, recCSP => (recCSP.Product?.ProductName, recCSP.Count, recCSP.Price)),
                        Assemblies = rec.PurchaseAssemblies.ToDictionary(recCSP => recCSP.AssemblyId, recCSP => (recCSP.Assembly?.AssemblyName, recCSP.Count, recCSP.Cost))
                    }).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PurchaseViewModel GetElement(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var purchase = context.Purchases
                    .Include(rec => rec.PurchaseProducts)
                    .ThenInclude(rec => rec.Product)
                    .Include(rec => rec.PurchaseAssemblies)
                    .ThenInclude(rec => rec.Assembly)
                    .Include(rec => rec.Buyer)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.PurchaseName == model.PurchaseName);
                return purchase != null ?
                new PurchaseViewModel
                {
                    Id = purchase.Id,
                    PurchaseName = purchase.PurchaseName,
                    BuyerId = purchase.BuyerId,
                    TotalCost = purchase.TotalCost,
                    DatePurchase = purchase.DatePurchase,
                    Products = purchase.PurchaseProducts.ToDictionary(recCSP => recCSP.ProductId, recCSP => (recCSP.Product?.ProductName, recCSP.Count, recCSP.Price)),
                    Assemblies = purchase.PurchaseAssemblies.ToDictionary(recCSP => recCSP.AssemblyId, recCSP => (recCSP.Assembly?.AssemblyName, recCSP.Count, recCSP.Cost))
                } :
                null;
            }
        }

        public void Insert(PurchaseBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Purchase(), context);
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

        public void Update(PurchaseBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Purchases.FirstOrDefault(rec => rec.Id == model.Id || rec.PurchaseName == model.PurchaseName);
                        if (element == null)
                        {
                            throw new Exception("Покупка не найдена");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(PurchaseBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Purchase element = context.Purchases.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Purchases.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Покупка не найдена");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="purchase"></param>
        /// <returns></returns>
        public Purchase CreateModel(PurchaseBindingModel model, Purchase purchase, ComputerEquipmentStoreDatabase context)
        {
            purchase.PurchaseName = model.PurchaseName;
            purchase.BuyerId = (int)model.BuyerId;
            purchase.TotalCost = model.TotalCost;
            purchase.DatePurchase = model.DatePurchase;
            if (purchase.Id == 0)
            {
                context.Purchases.Add(purchase);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                List<PurchaseProduct> purchaseProducts = context.PurchaseProducts.Where(rec => rec.PurchaseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели

                if (model.Products != null)
                {
                    context.PurchaseProducts.RemoveRange(purchaseProducts.Where(rec => !model.Products.ContainsKey(rec.ProductId)).ToList());

                    //обновляем кол-во и цену у записей, которые существуют
                    foreach (var updateProducts in purchaseProducts)
                    {
                        if (model.Products.ContainsKey(updateProducts.ProductId))
                        {
                            updateProducts.Count = model.Products[updateProducts.ProductId].Item2;
                            updateProducts.Price = model.Products[updateProducts.ProductId].Item3;
                            model.Products.Remove(updateProducts.ProductId);
                        }
                    }
                }
                context.SaveChanges();

                List<PurchaseAssembly> purchaseAssemblies = context.PurchaseAssemblies.Where(rec => rec.PurchaseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.PurchaseAssemblies.RemoveRange(purchaseAssemblies.Where(rec => !model.Assemblies.ContainsKey(rec.AssemblyId)).ToList());
                
                //обновляем кол-во и цену у записей, которые существуют
                foreach (var updateAssemblies in purchaseAssemblies)
                {

                    Console.WriteLine(updateAssemblies.AssemblyId);
                    
                    if (model.Assemblies.ContainsKey(updateAssemblies.AssemblyId))
                    { 
                        updateAssemblies.Count = model.Assemblies[updateAssemblies.AssemblyId].Item2;
                        updateAssemblies.Cost = model.Assemblies[updateAssemblies.AssemblyId].Item3;
                        model.Assemblies.Remove(updateAssemblies.AssemblyId);
                    }
                }

                context.SaveChanges();
            }
            // добавили новые
            foreach (KeyValuePair<int, (string, int, decimal)> CSP in model.Products)
            {
                context.PurchaseProducts.Add(new PurchaseProduct
                {
                    PurchaseId = purchase.Id,
                    ProductId = CSP.Key,
                    Count = CSP.Value.Item2,
                    Price = CSP.Value.Item3

                });
                context.SaveChanges();
            }
            
            foreach (KeyValuePair<int, (string, int, decimal)> CSP in model.Assemblies)
                {
                    context.PurchaseAssemblies.Add(new PurchaseAssembly
                    {
                        PurchaseId = purchase.Id,
                        AssemblyId = CSP.Key,
                        Count = CSP.Value.Item2,
                        Cost = CSP.Value.Item3

                    });
                    context.SaveChanges();

                Console.WriteLine("Добавляем сборку" + CSP.Key);
            }
            
            return purchase;
        }
    }
}
