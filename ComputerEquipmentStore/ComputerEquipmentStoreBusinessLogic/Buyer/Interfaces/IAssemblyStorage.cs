using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    public interface IAssemblyStorage
    {
        List<AssemblyViewModel> GetFullList(int BuyerId);

        List<AssemblyViewModel> GetFilteredList(AssemblyBindingModel model);

        AssemblyViewModel GetElement(AssemblyBindingModel model);

        void Insert(AssemblyBindingModel model);

        void Update(AssemblyBindingModel model);

        void Delete(AssemblyBindingModel model);
    }
}
