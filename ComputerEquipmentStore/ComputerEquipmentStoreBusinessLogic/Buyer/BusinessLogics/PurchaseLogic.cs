using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    /// <summary>
    /// Логика покупки
    /// </summary>
    public class PurchaseLogic
    {
        /// <summary>
        /// Хранилище покупок
        /// </summary>
        private readonly IPurchaseStorage purchaseStorage;

        /// <summary>
        /// Конструктор логики покупки
        /// </summary>
        /// <param name="purchaseStorage"></param>
        public PurchaseLogic(IPurchaseStorage purchaseStorage)
        {
            this.purchaseStorage = purchaseStorage;
        }

        /// <summary>
        /// Получить список покупок (либо одной покупки)
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        /// <param name="BuyerId"> ID покупателя </param>
        /// <returns> Список покупок (либо одна покупка) </returns>
        public List<PurchaseViewModel> Read(PurchaseBindingModel model, int BuyerId)
        {
            if (model == null)
            {
                return purchaseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchaseViewModel>
                {
                    purchaseStorage.GetElement(model)
                };
            }
            return purchaseStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить покупку
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        public void CreateOrUpdate(PurchaseBindingModel model)
        {
            var element = purchaseStorage.GetElement(new PurchaseBindingModel
            {
                PurchaseName = model.PurchaseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть покупка с таким названием");
            }
            if (model.Id.HasValue)
            {
                purchaseStorage.Update(model);
            }
            else
            {
                purchaseStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить покупку
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        public void Delete(PurchaseBindingModel model)
        {
            var element = purchaseStorage.GetElement(new PurchaseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Покупка не найдена");
            }
            purchaseStorage.Delete(model);
        }
    }
}
