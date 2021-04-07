using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    public class AssemblyLogic
    {
        private readonly IAssemblyStorage _assemblyStorage;
        public AssemblyLogic(IAssemblyStorage assemblyStorage)
        {
            this._assemblyStorage = assemblyStorage;
        }
        public List<AssemblyViewModel> Read(AssemblyBindingModel model, int BuyerId)
        {
            if (model == null)
            {
                return _assemblyStorage.GetFullList(BuyerId);
            }
            if (model.Id.HasValue)
            {
                return new List<AssemblyViewModel>
                {
                    _assemblyStorage.GetElement(model)
                };
            }
            return _assemblyStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(AssemblyBindingModel model)
        {
            var element = _assemblyStorage.GetElement(new AssemblyBindingModel
            {
                AssemblyName = model.AssemblyName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сборка с таким названием");
            }
            if (model.Id.HasValue)
            {
                _assemblyStorage.Update(model);
            }
            else
            {
                _assemblyStorage.Insert(model);
            }
        }
        public void Delete(AssemblyBindingModel model)
        {
            var element = _assemblyStorage.GetElement(new AssemblyBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Сборка не найдена");
            }
            _assemblyStorage.Delete(model);
        }
    }
}
