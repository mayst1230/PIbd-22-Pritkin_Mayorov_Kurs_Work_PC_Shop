using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using ComputerEquipmentStoreDatabaseImplement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStoreEquipmentDatabaseImplement.Implements
{
    public class SellerStorage : ISellerStorage
    {
        public List<SellerViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Sellers
                .Select(rec => new SellerViewModel
                {
                    Id = rec.Id,
                    Login = rec.Login,
                    Password = rec.Password
                }).ToList();
            }
        }

        public List<SellerViewModel> GetFilteredList(SellerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Sellers
                .Where(rec => rec.Login.Equals(model.Login) && rec.Password.Equals(model.Password))
               .Select(rec => new SellerViewModel
               {
                   Id = rec.Id,
                   Login = rec.Login,
                   Password = rec.Password
               }).ToList();
            }
        }
        public SellerViewModel GetElement(SellerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var seller = context.Sellers
                .FirstOrDefault(rec => rec.Login == model.Login || rec.Id == model.Id);
                return seller != null ?
                new SellerViewModel
                {
                    Id = seller.Id,
                    Login = seller.Login,
                    Password = seller.Password
                } : null;
            }
        }
        public void Insert(SellerBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Sellers.Add(CreateModel(model, new Seller()));
                context.SaveChanges();
            }
        }
        public void Update(SellerBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var user = context.Sellers.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Продавец не найден");
                }
                CreateModel(model, user);
                context.SaveChanges();
            }
        }
        public void Delete(SellerBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Seller seller = context.Sellers.FirstOrDefault(rec => rec.Id == model.Id);
                if (seller != null)
                {
                    context.Sellers.Remove(seller);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Продавец не найден");
                }
            }
        }
        private Seller CreateModel(SellerBindingModel model, Seller seller)
        {
            seller.Login = model.Login;
            seller.Password = model.Password;
            return seller;
        }
    }
}