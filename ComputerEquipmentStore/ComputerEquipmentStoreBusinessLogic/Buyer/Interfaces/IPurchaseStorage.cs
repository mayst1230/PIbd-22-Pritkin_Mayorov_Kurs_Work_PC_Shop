using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища покупок
    /// </summary>
    public interface IPurchaseStorage
    {
        /// <summary>
        /// Метод получения полного списка покупок
        /// </summary>
        /// <returns> Список покупок </returns>
        List<PurchaseViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка покупок
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        /// <returns> Список покупок </returns>
        List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model);

        /// <summary>
        /// Метод получения покупки
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        /// <returns> Модель покупки </returns>
        PurchaseViewModel GetElement(PurchaseBindingModel model);

        /// <summary>
        /// Добавить новую покупку
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        void Insert(PurchaseBindingModel model);

        /// <summary>
        /// Обновить покупку
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        void Update(PurchaseBindingModel model);

        /// <summary>
        /// Удалить покупку
        /// </summary>
        /// <param name="model"> Модель покупки </param>
        void Delete(PurchaseBindingModel model);
    }
}
