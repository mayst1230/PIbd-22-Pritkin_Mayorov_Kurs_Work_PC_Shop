using System;
using System.Collections.Generic;
using System.Text;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using System.Linq;

namespace ComputerEquipmentStoreDatabaseImplement.Implements
{
    public class AssemblyStorage : IAssemblyStorage
    {
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AssemblyViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Assemblies.Select(rec => new AssemblyViewModel
                {
                    Id = rec.Id,
                    Cost = rec.Cost,
                    AssemblyName = rec.AssemblyName,
                    BuyerId = rec.BuyerId

                })
                .ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<AssemblyViewModel> GetFilteredList(AssemblyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Assemblies
                .Where(rec => rec.Id.Equals(model.Id))
                .Select(rec => new AssemblyViewModel
                {
                    Id = rec.Id,
                    Cost = rec.Cost,
                    AssemblyName = rec.AssemblyName,
                    BuyerId = rec.BuyerId
                })
                .ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AssemblyViewModel GetElement(AssemblyBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var component = context.Assemblies.FirstOrDefault(
                    rec => rec.Id == model.Id);
                return component != null ?
                new AssemblyViewModel
                {
                    Id = component.Id,
                    Cost = component.Cost,
                    AssemblyName = component.AssemblyName,
                    BuyerId = component.BuyerId
                }
                : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Insert(AssemblyBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Assemblies.Add(CreateModel(model, new Assembly()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Update(AssemblyBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var element = context.Assemblies.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(AssemblyBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Assembly element = context.Assemblies.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Assemblies.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private Assembly CreateModel(AssemblyBindingModel model, Assembly assembly)
        {
            assembly.Cost = model.Cost;
            assembly.AssemblyName = model.AssemblyName;
            assembly.BuyerId = model.BuyerId;
            return assembly;
        }
    }
}
