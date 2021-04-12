using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    /// <summary>
    /// Логика покупателя
    /// </summary>
    public class BuyerLogic
    {
        /// <summary>
        /// Хранилище покупателей
        /// </summary>
        private readonly IBuyerStorage buyerStorage;

        /// <summary>
        /// Конструктор логики покупателей
        /// </summary>
        /// <param name="buyerStorage"> Хранилище покупателей </param>
        public BuyerLogic(IBuyerStorage buyerStorage)
        {
            this.buyerStorage = buyerStorage;
        }

        /// <summary>
        /// Получить список покупателей (либо одного покупателя)
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        /// <returns> Список с покупателей (либо один покупатель) </returns>
        public List<BuyerViewModel> Read(BuyerBindingModel model) 
        {
            if (model == null)
            {
                return buyerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BuyerViewModel> { buyerStorage.GetElement(model) };
            }
            return buyerStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить покупателя
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        public void CreateOrUpdate(BuyerBindingModel model)
        {
            var element = buyerStorage.GetElement(new BuyerBindingModel
            {
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть покупатель с таким никнеймом");
            }
            if (model.Id.HasValue)
            {
                buyerStorage.Update(model);
            }
            else
            {
                buyerStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить покупателя
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BuyerBindingModel model)
        {
            var element = buyerStorage.GetElement(new BuyerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупатель не найден");
            }
            buyerStorage.Delete(model);
        }
    }
}
