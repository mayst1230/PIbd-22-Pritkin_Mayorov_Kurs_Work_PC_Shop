using System;
using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using System.Linq;

namespace ComputerEquipmentStoreDatabaseImplement.Implements
{
    public class BuyerStorage : IBuyerStorage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BuyerViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Buyers.Select(rec => new BuyerViewModel
                {
                    Id = rec.Id,
                    Login = rec.Login,
                    Password = rec.Password

                })
                .ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BuyerViewModel> GetFilteredList(BuyerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Buyers
                .Where(rec => rec.Login.Equals(model.Login) && rec.Password.Equals(model.Password))
                .Select(rec => new BuyerViewModel
                {
                    Id = rec.Id,
                    Login = rec.Login,
                    Password = rec.Password
                })
                .ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BuyerViewModel GetElement(BuyerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var component = context.Buyers.FirstOrDefault(
                    rec => rec.Login == model.Login || rec.Id == model.Id);
                return component != null ?
                new BuyerViewModel
                {
                    Id = component.Id,
                    Login = component.Login,
                    Password = component.Password
                }
                : null;
            }
        }

        /// <summary>
        /// Вставить нового покупателя в базу данных
        /// </summary>
        /// <param name="model"></param>
        public void Insert(BuyerBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Buyers.Add(CreateModel(model, new Buyer()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Измененить покупателя в базе данных 
        /// </summary>
        /// <param name="model"></param>
        public void Update(BuyerBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var element = context.Buyers.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(BuyerBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Buyer element = context.Buyers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Buyers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        /// <summary>
        /// Создать модель покупателя
        /// </summary>
        /// <param name="model"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private Buyer CreateModel(BuyerBindingModel model, Buyer buyer)
        {
            buyer.Login = model.Login;
            buyer.Password = model.Password;
            return buyer;
        }
    }
}
