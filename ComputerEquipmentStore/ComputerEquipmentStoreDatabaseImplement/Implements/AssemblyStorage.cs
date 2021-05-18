﻿using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerEquipmentStoreDatabaseImplement.Implements
{
    public class AssemblyStorage : IAssemblyStorage
    {

        public List<AssemblyViewModel> GetFullList()
        {
            using (ComputerEquipmentStoreDatabase context = new ComputerEquipmentStoreDatabase())
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
                         Allowance = rec.Allowance,
                         AssemblyName = rec.AssemblyName,
                         BuyerId = rec.BuyerId,
                         Components = rec.AssemblyComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => (recCSP.Component?.ComponentName, recCSP.Count, recCSP.Price))
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
            using (ComputerEquipmentStoreDatabase context = new ComputerEquipmentStoreDatabase())
            {
                return context.Assemblies
                    .Include(rec => rec.Buyer)
                    .Include(rec => rec.AssemblyComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.AssemblyName.Contains(model.AssemblyName) || (model.BuyerId.HasValue && rec.BuyerId == model.BuyerId))
                    .ToList()
                    .Select(rec => new AssemblyViewModel
                    {
                        Id = rec.Id,
                        Cost = rec.Cost,
                        Allowance = rec.Allowance,
                        AssemblyName = rec.AssemblyName,
                        BuyerId = rec.BuyerId,
                        Components = rec.AssemblyComponents.ToDictionary(recCSP => recCSP.ComponentId, recCSP => (recCSP.Component?.ComponentName, recCSP.Count, recCSP.Price)),

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
            using (ComputerEquipmentStoreDatabase context = new ComputerEquipmentStoreDatabase())
            {
                Assembly assembly = context.Assemblies
                    .Include(rec => rec.AssemblyComponents)
                    .ThenInclude(rec => rec.Component)
                    .Include(rec => rec.Buyer)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.AssemblyName == model.AssemblyName);
                return assembly != null ?
                new AssemblyViewModel
                {
                    Id = assembly.Id,
                    Cost = assembly.Cost,
                    Allowance = assembly.Allowance,
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
            using (ComputerEquipmentStoreDatabase context = new ComputerEquipmentStoreDatabase())
            {
                try
                {
                    context.Assemblies.Add(CreateModel(model, new Assembly(), context));
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }       
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Update(AssemblyBindingModel model)
        {
            using (ComputerEquipmentStoreDatabase context = new ComputerEquipmentStoreDatabase())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Assembly element = context.Assemblies.FirstOrDefault(rec => rec.Id == model.Id || rec.AssemblyName == model.AssemblyName);
                        if (element == null)
                        {
                            throw new Exception("Сборка не найдена");
                        }
                        CreateModel(model, element, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(AssemblyBindingModel model)
        {
            using (ComputerEquipmentStoreDatabase context = new ComputerEquipmentStoreDatabase())
            {
                Assembly element = context.Assemblies.FirstOrDefault(rec => rec.Id == model.Id || rec.AssemblyName == model.AssemblyName);
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
        private Assembly CreateModel(AssemblyBindingModel model, Assembly assembly, ComputerEquipmentStoreDatabase context)
        {
            assembly.AssemblyName = model.AssemblyName;
            assembly.BuyerId = (int)model.BuyerId;
            assembly.Cost = model.Cost;
            assembly.Allowance = model.Allowance;

            if (assembly.Id == 0)
            {
                context.Assemblies.Add(assembly);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                List<AssemblyComponent> assemblyComponent = context.AssemblyComponents.Where(rec => rec.AssemblyId == model.Id.Value).ToList();
               
                if (model.Components != null)
                {
                    // удалили те, которых нет в модели
                    context.AssemblyComponents.RemoveRange(assemblyComponent.Where(rec => !model.Components.ContainsKey(rec.ComponentId)).ToList());
                    //обновляем кол-во и цену у записей, которые существуют
                    foreach (AssemblyComponent updateComponent in assemblyComponent)
                    {
                        if (model.Components.ContainsKey(updateComponent.ComponentId))
                        {
                            updateComponent.Count = model.Components[updateComponent.ComponentId].Item2;
                            updateComponent.Price = model.Components[updateComponent.ComponentId].Item3;
                            model.Components.Remove(updateComponent.ComponentId);
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
            }
            return assembly;
        }
    }
}