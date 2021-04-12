using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища сборок
    /// </summary>
    public interface IAssemblyStorage
    {
        /// <summary>
        /// Метод получения полного списка сборок
        /// </summary>
        /// <returns> Список сборок </returns>
        List<AssemblyViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка сборок
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Список сборок </returns>
        List<AssemblyViewModel> GetFilteredList(AssemblyBindingModel model);

        /// <summary>
        /// Метод получения сборки
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        /// <returns> Модель сборки </returns>
        AssemblyViewModel GetElement(AssemblyBindingModel model);

        /// <summary>
        /// Добавить новую сборку
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        void Insert(AssemblyBindingModel model);

        /// <summary>
        /// Обновить сборку
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        void Update(AssemblyBindingModel model);

        /// <summary>
        /// Удалить сборку
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        void Delete(AssemblyBindingModel model);
    }
}
