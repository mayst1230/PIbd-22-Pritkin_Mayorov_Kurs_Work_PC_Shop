using ComputerEquipmentStoreBusinessLogic.HelperModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    /// <summary>
    /// Логика отчета покупателя
    /// </summary>
    public class ReportLogicBuyer
    {
        /// <summary>
        /// Хранилище покупок
        /// </summary>
        private readonly IPurchaseStorage purchaseStorage;

        /// <summary>
        /// Хранилище товаров
        /// </summary>
        private readonly IProductStorage productStorage;

        /// <summary>
        /// Хранилище сборок
        /// </summary>
        private readonly IAssemblyStorage assemblyStorage;

        /// <summary>
        /// Хранилище комментариев
        /// </summary>
        private readonly ICommentStorage componentStorage;

        /// <summary>
        /// Логика товара
        /// </summary>
        private readonly ProductLogic productLogic;

        /// <summary>
        /// Логика сборки
        /// </summary>
        private readonly AssemblyLogic assemblyLogic;

        /// <summary>
        /// Логика комплектующего
        /// </summary>
        private readonly ComponentLogic componentLogic;

        /// <summary>
        /// Логика комментария
        /// </summary>
        private readonly CommentLogic commentLogic;
        
        /// <summary>
        /// Конструктор логики отчета покупателя
        /// </summary>
        /// <param name="purchaseStorage"> Хранилище покупок </param>
        /// <param name="productStorage"> Хранилище товаров </param>
        /// <param name="assemblyStorage"> Хранилище сборок </param>
        /// <param name="componentStorage"> Хранилище компонентов </param>
        /// <param name="productLogic"> Логика товара </param>
        /// <param name="assemblyLogic"> Логика сборки </param>
        /// <param name="componentLogic"> Логика комплектующего </param>
        /// <param name="commentLogic"> Логика комментария </param>
        public ReportLogicBuyer(
            IPurchaseStorage purchaseStorage,
            IProductStorage productStorage,
            IAssemblyStorage assemblyStorage,
            ICommentStorage componentStorage,
            ProductLogic productLogic,
            AssemblyLogic assemblyLogic,
            ComponentLogic componentLogic,
            CommentLogic commentLogic)
        {
            this.purchaseStorage = purchaseStorage;
            this.productStorage = productStorage;
            this.assemblyStorage = assemblyStorage;
            this.componentStorage = componentStorage;
            this.productLogic = productLogic;
            this.assemblyLogic = assemblyLogic;
            this.componentLogic = componentLogic;
            this.commentLogic = commentLogic;
        }

        /// <summary>
        /// Возвращает список отчетов по компонентам выбранных покупок
        /// </summary>
        /// <param name="selectedPurchases"> Список выбранных покупок </param>
        /// <returns> Список компонентов </returns>
        public List<ReportPurchaseComponentsViewModel> GetPurchaseComponents(List<PurchaseViewModel> selectedPurchases)  
        {
            var list = new List<ReportPurchaseComponentsViewModel>();//Тут будет результат

            selectedPurchases.ForEach(purchase =>
            {
                //Тут будет запись в список
                var record = new ReportPurchaseComponentsViewModel
                {
                    PurchaseName = purchase.PurchaseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                var neededProducts = new List<ProductViewModel>();//Сюда записываются все товары покупки
                var neededAssemblies = new List<AssemblyViewModel>();//Сюда записываются все сборки покупки

                purchase.Products.ToList().ForEach(product =>
                {
                    ProductViewModel productViewModel = productLogic.Read(new ProductBindingModel
                    {
                        Id = product.Key
                    })?[0];

                    neededProducts.Add(productViewModel);
                });

                purchase.Assemblies.ToList().ForEach(assembly =>
                {
                    AssemblyViewModel assemblyViewModel = assemblyLogic.Read(new AssemblyBindingModel
                    {
                        Id = assembly.Key
                    })?[0];

                    neededAssemblies.Add(assemblyViewModel);
                });

                neededProducts.ForEach(neededProduct =>
                {
                    int totalCount = 0;

                    neededProduct.Components.ToList().ForEach(component =>
                    {
                        ComponentViewModel componentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(componentViewModel.ComponentName, neededProduct.Components[componentViewModel.Id].Item2 * purchase.Products[neededProduct.Id].Item2));
                        totalCount += neededProduct.Components[componentViewModel.Id].Item2;
                    });

                    record.TotalCount += totalCount * purchase.Products[neededProduct.Id].Item2;
                });

                neededAssemblies.ForEach(neededAssembly =>
                {
                    int totalCount = 0;

                    neededAssembly.Components.ToList().ForEach(component =>
                    {
                        ComponentViewModel commentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(commentViewModel.ComponentName, neededAssembly.Components[commentViewModel.Id].Item2 * purchase.Assemblies[neededAssembly.Id].Item2));
                        totalCount += neededAssembly.Components[commentViewModel.Id].Item2;
                    });

                    record.TotalCount += totalCount * purchase.Assemblies[neededAssembly.Id].Item2;
                });

                list.Add(record);
            });

            return list;
        }

        /// <summary>
        /// Получить список отчетов по комплектующим и комментариям за выбранный период
        /// </summary>
        /// <param name="model"> Модель отчета покупателя </param>
        /// <returns> Список отчетов по комплектующим и комментариям </returns>
        public List<ReportPurchasesViewModel> GetInfoAboutPurchases(ReportBindingModelBuyer model)
        {
            var list = new List<ReportPurchasesViewModel>(); //Тут будет результат

            List<PurchaseViewModel> neededPurchases = purchaseStorage.GetFilteredList(new PurchaseBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                BuyerId = model.BuyerId
            });

            neededPurchases.ForEach(selectedPurchase =>
            {
                //Тут будет запись в список
                var record = new ReportPurchasesViewModel
                {
                    PurchaseName = selectedPurchase.PurchaseName,
                    DatePurchase = selectedPurchase.DatePurchase,
                    Components = new List<Tuple<string, int>>(),
                    Comments = new List<Tuple<string, DateTime>>(),
                };

                var neededProducts = new List<ProductViewModel>();//Сюда записываются все товары покупки
                var neededAssemblies = new List<AssemblyViewModel>();//Сюда записываются все сборки покупки

                selectedPurchase.Products.ToList().ForEach(product =>
                {
                    ProductViewModel productViewModel = productLogic.Read(new ProductBindingModel
                    {
                        Id = product.Key
                    })?[0];

                    neededProducts.Add(productViewModel);
                });

                selectedPurchase.Assemblies.ToList().ForEach(assembly =>
                {
                    AssemblyViewModel assemblyViewModel = assemblyLogic.Read(new AssemblyBindingModel
                    {
                        Id = assembly.Key
                    })?[0];

                    neededAssemblies.Add(assemblyViewModel);
                });

                neededProducts.ForEach(neededProduct =>
                {
                    int totalCount = 0;

                    neededProduct.Components.ToList().ForEach(component =>
                    {
                        ComponentViewModel commentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(commentViewModel.ComponentName, neededProduct.Components[commentViewModel.Id].Item2 * selectedPurchase.Products[neededProduct.Id].Item2));
                        totalCount += neededProduct.Components[commentViewModel.Id].Item2;
                    });

                    record.Count += totalCount * selectedPurchase.Products[neededProduct.Id].Item2;
                });

                neededProducts.ForEach(neededProduct =>
                {
                    int totalCount = 0;

                    neededProduct.Components.ToList().ForEach(component =>
                    {
                        ComponentViewModel commentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(commentViewModel.ComponentName, neededProduct.Components[commentViewModel.Id].Item2 * selectedPurchase.Products[neededProduct.Id].Item2));
                        totalCount += neededProduct.Components[commentViewModel.Id].Item2;
                    });

                    record.Count += totalCount * selectedPurchase.Products[neededProduct.Id].Item2;

                });

                neededAssemblies.ForEach(neededAssembly =>
                {
                    int totalCount = 0;

                    neededAssembly.Components.ToList().ForEach(component =>
                    {
                        ComponentViewModel componentViewModel = componentLogic.Read(new ComponentBindingModel
                        {
                            Id = component.Key
                        })?[0];

                        record.Components.Add(new Tuple<string, int>(componentViewModel.ComponentName, neededAssembly.Components[componentViewModel.Id].Item2 * selectedPurchase.Assemblies[neededAssembly.Id].Item2));
                        totalCount += neededAssembly.Components[componentViewModel.Id].Item2;
                    });

                    record.Count += totalCount * selectedPurchase.Assemblies[neededAssembly.Id].Item2;




                    var listComment = commentLogic.Read(new CommentBindingModel
                    {
                        AssemblyId = neededAssembly.Id
                    });





                    Console.WriteLine(listComment.Count.ToString());

                    if (listComment != null)
                    {
                        foreach (var comment in listComment)
                        {
                            record.Comments.Add(new Tuple<string, DateTime>(comment.Text, comment.DateComment));
                        }       
                    }
                });
                list.Add(record);
            });

            return list;
        }

        /// <summary>
        /// Сохранение в файл-Word покупок с указанием какие комплектующие в них используются
        /// </summary>
        /// <param name="model"> Модель отчета покупателя </param>
        /// <param name="purchases"> Список покупок </param>
        public void SavePurchaseComponentToWordFile(ReportBindingModelBuyer model, List<PurchaseViewModel> purchases)
        {
            SaveToWord.CreateDoc(new WordInfoBuyer
            {
                FileName = model.FileName,
                Title = "Список комплектующих",
                PurchaseComponents = GetPurchaseComponents(purchases)
            });
        }

        /// <summary>
        /// Сохранение в файл-Excel покупок с указанием какие комплектующие в них используются
        /// </summary>
        /// <param name="model"> Модель отчета покупателя </param>
        /// <param name="purchases"> Список покупок </param>
        public void SavePurchaseComponentToExcelFile(ReportBindingModelBuyer model, List<PurchaseViewModel> purchases)
        {
            SaveToExcel.CreateDoc(new ExcelInfoBuyer
            {
                FileName = model.FileName,
                Title = "Список комплектующих",
                PurchaseComponents = GetPurchaseComponents(purchases)
            });
        }

        /// <summary>
        /// Сохранение в файл-PDF отчета за период по покупкам с указанием какие 
        /// комплектующие сборок и комментарии сборок в них используются
        /// </summary>
        /// <param name="model"> Модель отчета покупателя </param>
        [Obsolete]
        public void SaveToPdfFile(ReportBindingModelBuyer model)
        {
            SaveToPdf.CreateDoc(new PdfInfoBuyer
            {
                FileName = model.FileName,
                Title = "Список покупок",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                BuyerId = model.BuyerId,
                InfoAboutPurchases = GetInfoAboutPurchases(model)
            });
        }
    }
}
