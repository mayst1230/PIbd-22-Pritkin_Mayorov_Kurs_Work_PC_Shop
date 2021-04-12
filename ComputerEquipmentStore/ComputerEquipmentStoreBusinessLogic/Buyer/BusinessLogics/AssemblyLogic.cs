using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    /// <summary>
    /// Логика сборки
    /// </summary>
    public class AssemblyLogic
    {
        /// <summary>
        /// Хранилище сборок
        /// </summary>
        private readonly IAssemblyStorage assemblyStorage;

        /// <summary>
        /// Конструктор логики сборки
        /// </summary>
        /// <param name="assemblyStorage"> Хранилище сборок </param>
        public AssemblyLogic(IAssemblyStorage assemblyStorage)
        {
            this.assemblyStorage = assemblyStorage;
        }

        /// <summary>
        /// Получить список сборок (либо одну сборку)
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        /// <returns> Список сборок (либо одна сборка) </returns>
        public List<AssemblyViewModel> Read(AssemblyBindingModel model)
        {
            if (model == null)
            {
                return assemblyStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<AssemblyViewModel>
                {
                    assemblyStorage.GetElement(model)
                };
            }
            return assemblyStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить сборку
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        public void CreateOrUpdate(AssemblyBindingModel model)
        {
            var element = assemblyStorage.GetElement(new AssemblyBindingModel
            {
                AssemblyName = model.AssemblyName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сборка с таким названием");
            }
            if (model.Id.HasValue)
            {
                assemblyStorage.Update(model);
            }
            else
            {
                assemblyStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить сборку
        /// </summary>
        /// <param name="model"> Модель сборки </param>
        public void Delete(AssemblyBindingModel model)
        {
            var element = assemblyStorage.GetElement(new AssemblyBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Сборка не найдена");
            }
            assemblyStorage.Delete(model);
        }
    }
}
