using System;
using System.Collections.Generic;
using System.Text;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using System.Linq;

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
                return context.Purchases.Select(rec => new PurchaseViewModel
                {
                    Id = rec.Id,
                    TotalCost = rec.TotalCost,
                    DatePurchase = rec.DatePurchase,
                    BuyerId = rec.BuyerId
                })
                .ToList();
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
                .Where(rec => rec.Id.Equals(model.Id))
                .Select(rec => new PurchaseViewModel
                {
                    Id = rec.Id,
                    TotalCost = rec.TotalCost,
                    DatePurchase = rec.DatePurchase,
                    BuyerId = rec.BuyerId
                })
                .ToList();
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
                var component = context.Purchases.FirstOrDefault(
                    rec => rec.Id == model.Id);
                return component != null ?
                new PurchaseViewModel
                {
                    Id = component.Id,
                    TotalCost = component.TotalCost,
                    DatePurchase = component.DatePurchase,
                    BuyerId = component.BuyerId
                }
                : null;
            }
        }

        public void Insert(PurchaseBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Purchases.Add(CreateModel(model, new Purchase()));
                context.SaveChanges();
            }
        }

        public void Update(PurchaseBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var element = context.Purchases.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
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
                    throw new Exception("Элемент не найден");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="purchase"></param>
        /// <returns></returns>
        private Purchase CreateModel(PurchaseBindingModel model, Purchase purchase)
        {
            purchase.TotalCost = model.TotalCost;
            purchase.DatePurchase = model.DatePurchase;
            purchase.BuyerId = model.BuyerId;
            return purchase;
        }
    }
}
