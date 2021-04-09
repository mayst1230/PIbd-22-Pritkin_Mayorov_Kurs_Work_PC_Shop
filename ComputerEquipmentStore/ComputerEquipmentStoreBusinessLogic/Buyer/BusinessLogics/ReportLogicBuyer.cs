using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.HelperModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using System.Collections.Generic;
using System;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    public class ReportLogicBuyer
    {

        private readonly IPurchaseStorage purchaseStorage;
        private readonly IProductStorage productStorage;
        private readonly IAssemblyStorage assemblyStorage;
        private readonly ICommentStorage componentStorage;

        private readonly ProductLogic productLogic;
        private readonly AssemblyLogic assemblyLogic;
        private readonly ComponentLogic componentLogic;

        public ReportLogicBuyer(
            IPurchaseStorage purchaseStorage,
            IProductStorage productStorage,
            IAssemblyStorage assemblyStorage,
            ICommentStorage componentStorage,
            ProductLogic productLogic,
            AssemblyLogic assemblyLogic,
            ComponentLogic componentLogic)
        {
            this.purchaseStorage = purchaseStorage;
            this.productStorage = productStorage;
            this.assemblyStorage = assemblyStorage;
            this.componentStorage = componentStorage;
            this.productLogic = productLogic;
            this.assemblyLogic = assemblyLogic;
            this.componentLogic = componentLogic;
        }



        /// <summary>
        /// Возвращает список отчетов по компонентам выбранных покупок
        /// </summary>
        /// <param name="selectedPurchases"></param>
        /// <returns></returns>
        public List<ReportPurchaseComponentsViewModel> GetPurchaseComponents(List<PurchaseViewModel> selectedPurchases)  
        {

            var list = new List<ReportPurchaseComponentsViewModel>();//Тут будет результат

            foreach (var selectedPurchase in selectedPurchases)
            {

                //Тут будет запись в список
                var record = new ReportPurchaseComponentsViewModel
                {
                    PurchaseName = selectedPurchase.PurchaseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                var neededProducts = new List<ProductViewModel>();//Сюда записываются все товары покупки
                var neededAssemblies = new List<AssemblyViewModel>();//Сюда записываются все сборки покупки

                foreach (var product in selectedPurchase.Products)
                {
                    ProductViewModel productViewModel = productLogic.Read(new ProductBindingModel
                    {
                        Id = product.Key
                    })?[0];

                    neededProducts.Add(productViewModel);
                }

                foreach (var assembly in selectedPurchase.Assemblies)
                {
                    AssemblyViewModel assemblyViewModel = assemblyLogic.Read(new AssemblyBindingModel
                    {
                        Id = assembly.Key
                    })?[0];

                    neededAssemblies.Add(assemblyViewModel);
                }

                
                foreach (var neededProduct in neededProducts)
                {
                    int totalCount = 0;
                    foreach (var component in neededProduct.Components)
                    {

                        ComponentViewModel commentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(commentViewModel.ComponentName, neededProduct.Components[commentViewModel.Id].Item2 * selectedPurchase.Products[neededProduct.Id].Item2));
                        totalCount += neededProduct.Components[commentViewModel.Id].Item2;
                    }
                    record.TotalCount += totalCount * selectedPurchase.Products[neededProduct.Id].Item2;
                }
                

                foreach (var neededAssembly in neededAssemblies)
                {
                    int totalCount = 0;
                    foreach (var component in neededAssembly.Components)
                    {

                        ComponentViewModel commentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(commentViewModel.ComponentName, neededAssembly.Components[commentViewModel.Id].Item2 * selectedPurchase.Assemblies[neededAssembly.Id].Item2));
                        totalCount += neededAssembly.Components[commentViewModel.Id].Item2;
                    }
                    record.TotalCount += totalCount * selectedPurchase.Assemblies[neededAssembly.Id].Item2;
                }

                list.Add(record);
            }

            return list;
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SavePurchaseComponentToExcelFile(ReportBindingModelBuyer model, List<PurchaseViewModel> purchases)
        {
            SaveToExcel.CreateDoc(new ExcelInfoBuyer
            {
                FileName = model.FileName,
                Title = "Список компонентов",
                PurchaseComponents = GetPurchaseComponents(purchases)
            });
        }

        public void SavePurchaseComponentToWordFile(ReportBindingModelBuyer model, List<PurchaseViewModel> purchases)
        {
            SaveToWord.CreateDoc(new WordInfoBuyer
            {
                FileName = model.FileName,
                Title = "Список компонентов",
                PurchaseComponents = GetPurchaseComponents(purchases)
            });
        }
    }
}
