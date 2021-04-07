using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;

namespace ComputerEquipmentStoreDatabaseImplement.Implements
{
    public class AssemblyStorage : IAssemblyStorage
    {
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AssemblyViewModel> GetFullList(int BuyerId, bool superAccess)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                if (superAccess)
                {
                    return context.Assemblies
                         .Include(rec => rec.AssemblyComponents)
                         .ThenInclude(rec => rec.Component)
                         .Include(rec => rec.Buyer)
                         .ToList()
                         .Select(rec => new AssemblyViewModel
                         {
                             Id = rec.Id,
                             Cost = rec.Cost,
                             AssemblyName = rec.AssemblyName,
                             BuyerId = rec.BuyerId,
                             Components = rec.AssemblyComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => (recCSP.Component.ComponentName, recCSP.Count, recCSP.Price))
                         })
                        .ToList();
                } 
                else
                {
                    return context.Assemblies
                        .Include(rec => rec.AssemblyComponents)
                        .ThenInclude(rec => rec.Component)
                        .Include(rec => rec.Buyer)
                        .Where(rec => rec.BuyerId == BuyerId)
                        .ToList()
                        .Select(rec => new AssemblyViewModel
                        {
                            Id = rec.Id,
                            Cost = rec.Cost,
                            AssemblyName = rec.AssemblyName,
                            BuyerId = rec.BuyerId,
                            Components = rec.AssemblyComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => (recCSP.Component.ComponentName, recCSP.Count, recCSP.Price))
                        })
                    .ToList();
                }
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
                    .Include(rec => rec.AssemblyComponents)
                    .ThenInclude(rec => rec.Component)
                    .Include(rec => rec.Buyer)
                    .Where(rec => rec.Id.Equals(model.Id))
                    .ToList()
                    .Select(rec => new AssemblyViewModel
                    {
                        Id = rec.Id,
                        Cost = rec.Cost,
                        AssemblyName = rec.AssemblyName,
                        BuyerId = rec.BuyerId,
                        Components = rec.AssemblyComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => (recCSP.Component.ComponentName, recCSP.Count, recCSP.Price)),

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
                var assembly = context.Assemblies
                    .Include(rec => rec.AssemblyComponents)
                    .ThenInclude(rec => rec.Component)
                    .Include(rec => rec.Buyer)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return assembly != null ?
                new AssemblyViewModel
                {
                    Id = assembly.Id,
                    Cost = assembly.Cost,
                    AssemblyName = assembly.AssemblyName,
                    BuyerId = assembly.BuyerId,
                    Components = assembly.AssemblyComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => (recCSP.Component?.ComponentName, recCSP.Count, recCSP.Price)),
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
                context.Assemblies.Add(CreateModel(model, new Assembly(), context));
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
                CreateModel(model, element, context);
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
        private Assembly CreateModel(AssemblyBindingModel model, Assembly assembly,  ComputerEquipmentStoreDatabase context)
        {
            
            assembly.AssemblyName = model.AssemblyName;
            assembly.BuyerId = model.BuyerId;
            assembly.Cost = model.Cost;




            if (assembly.Id == 0)
            {
                context.Assemblies.Add(assembly);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                List<AssemblyComponent> assemblyComponent = context.AssemblyComponents.Where(rec => rec.AssemblyId == model.Id.Value).ToList();
                // удалили те, которых нет в модели

                if (model.Components != null)
                {
                    context.AssemblyComponents.RemoveRange(assemblyComponent.Where(rec => !model.Components.ContainsKey(rec.ComponentId)).ToList());

                    //обновляем кол-во и цену у записей, которые существуют
                    foreach (var updateComponent in assemblyComponent)
                    {
                        if (model.Components.ContainsKey(updateComponent.ComponentId))
                        {
                            updateComponent.Count = model.Components[updateComponent.ComponentId].Item2;
                            updateComponent.Price = model.Components[updateComponent.ComponentId].Item3;
                            model.Components.Remove(updateComponent.ComponentId);
                        }
                    }
                }
                context.SaveChanges();

                // добавили новые
                foreach (KeyValuePair<int, (string, int, decimal)> CSP in model.Components)
                {
                    context.AssemblyComponents.Add(new AssemblyComponent
                    {
                        AssemblyId = assembly.Id,
                        ComponentId = CSP.Key,
                        Count = CSP.Value.Item2,
                        Price = CSP.Value.Item3
                    });
                    context.SaveChanges();
                }
            }
            
            return assembly;
        }
    }
}
