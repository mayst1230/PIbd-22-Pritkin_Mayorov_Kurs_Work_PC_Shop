using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища покупателей
    /// </summary>
    public interface IBuyerStorage
    {
        /// <summary>
        /// Метод получения полного списка покупателей
        /// </summary>
        /// <returns> Список покупателей </returns>
        List<BuyerViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка покупателей
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        /// <returns> Список покупателей </returns>
        List<BuyerViewModel> GetFilteredList(BuyerBindingModel model);

        /// <summary>
        /// Метод получения покупателя
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        /// <returns> Модель покупателя </returns>
        BuyerViewModel GetElement(BuyerBindingModel model);

        /// <summary>
        /// Добавить нового покупателя
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        void Insert(BuyerBindingModel model);

        /// <summary>
        /// Обновить покупателя
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        void Update(BuyerBindingModel model);

        /// <summary>
        /// Удалить покупателя
        /// </summary>
        /// <param name="model"> Модель покупателя </param>
        void Delete(BuyerBindingModel model);
    }
}
