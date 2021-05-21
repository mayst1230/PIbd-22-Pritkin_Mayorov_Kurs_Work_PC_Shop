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
    public class ReportStorage
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ReportPurchaseComponentsViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {

                List<PurchaseViewModel> purchases = (new PurchaseStorage()).GetFilteredList(model);

                /*
                var i =  context.Purchases
                    .Include(rec => rec.Buyer)
                    .Include(rec => rec.PurchaseProducts)
                    .ThenInclude(rec => rec.Product)
                    .Include(rec => rec.PurchaseAssemblies)
                    .ThenInclude(rec => rec.Assembly)
                    .Where(rec =>
                    (rec.DatePurchase >= model.DateFrom && rec.DatePurchase <= model.DateTo && model.BuyerId.HasValue && rec.BuyerId == model.BuyerId)
                    ||
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
                */






                return context.Purchases.Where(rec => model.BuyerId.HasValue && rec.BuyerId == model.BuyerId
                    &&
                    rec.DatePurchase >= model.DateFrom
                    &&
                    rec.DatePurchase <= model.DateTo)
                    .Include(a => a.PurchaseProducts)
                    .ThenInclude(b => b.Product)
                    .ThenInclude(c => c.ProductComponents)
                    .ThenInclude(d => d.Component)
                    .Select(rec => new ReportPurchaseComponentsViewModel
                    {
                        PurchaseName = rec.PurchaseName,
                        TotalCount = 10,
                        //Components = rec.PurchaseProducts.ToDictionary(recCSP => recCSP.ProductId, recCSP => (recCSP.Product?.ProductName, recCSP.Count, recCSP.Price)),


                        //Components = rec.PurchaseProducts.ToList(new Tuple<string, int>( "",10 )),


                    }).ToList();
            }
        }






    }
}
