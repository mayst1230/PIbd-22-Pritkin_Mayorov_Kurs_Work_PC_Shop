using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.HelperModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IPurchaseStorage _purchaseStorage;
        private readonly IProductStorage _productStorage;
        private readonly IAssemblyStorage _assemblyStorage;

        public ReportLogic(IPurchaseStorage purchaseStorage, IProductStorage productStorage, IAssemblyStorage assemblyStorage)
        {
            _productStorage = productStorage;
            _purchaseStorage = purchaseStorage;
            _assemblyStorage = assemblyStorage;
        }

        //получение списка сборок по товарам
        private List<ReportAssemblyProductViewModel> GetAssemblyProduct(List<ProductViewModel> selectedProducts)
        {
            List<ReportAssemblyProductViewModel> record = new List<ReportAssemblyProductViewModel>();
            List<Buyer.ViewModels.AssemblyViewModel> listAssembly = _assemblyStorage.GetFullList();
            listAssembly.ForEach(assembly =>
            {
                Dictionary<int, (string, decimal)> neededProducts = new Dictionary<int, (string, decimal)>();
                selectedProducts.ForEach(product =>
                {
                    bool needed = true;
                    product.Components.ToList().ForEach(component =>
                    {
                        if (!assembly.Components.ContainsKey(component.Key))
                        {
                            needed = false;
                        }
                    });
                    if (needed)
                    {
                        neededProducts.Add(product.Id, (product.ProductName, product.Price));
                    }
                });
                if (neededProducts.Count > 0)
                {
                    record.Add(new ReportAssemblyProductViewModel
                    {
                        AssemblyName = assembly.AssemblyName,
                        Products = neededProducts
                    });
                }
            });
            return record;
        }

        //Получение списка комплектующих с указанием товаров и сборок за определенный период
        public List<ReportComponentsViewModel> GetComponentProductAssembly(ReportBindingModel model)
        {
            List<Buyer.ViewModels.PurchaseViewModel> purchases = _purchaseStorage.GetFilteredList(new PurchaseBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                ReportSeller = true
            });

            List<ReportComponentsViewModel> componentsProductAssembly = new List<ReportComponentsViewModel>();
            purchases.ForEach(purchase =>
            {
                purchase.Products.ToList().ForEach(product =>
                {
                    ProductViewModel view = _productStorage.GetElement(new ProductBindingModel
                    {
                        Id = product.Key
                    });
                    //выборка комплектуюших для отчета из товаров с ID продавца, который их создал
                    view.Components.Where(rec => view.SellerId == model.SellerId).ToList().ForEach(component =>
                    {
                        componentsProductAssembly.Add(new ReportComponentsViewModel
                        {
                            Component = component.Value.Item1,
                            DataSale = purchase.DatePurchase,
                            AssemblyProduct = view.ProductName
                        });
                    });
                    purchase.Assemblies.ToList().ForEach(assembly =>
                    {
                        Buyer.ViewModels.AssemblyViewModel viewAssembly = _assemblyStorage.GetElement(new AssemblyBindingModel
                        {
                            Id = assembly.Key
                        });
                        //выборка комплектуюших для отчета из сборок с ID продавца, который их создал
                        view.Components.Where(rec => view.SellerId == model.SellerId).ToList().ForEach(component =>
                        {
                            componentsProductAssembly.Add(new ReportComponentsViewModel
                            {
                                Component = component.Value.Item1,
                                DataSale = purchase.DatePurchase,
                                AssemblyProduct = viewAssembly.AssemblyName
                            });
                        });
                    });
                });
            });
            return componentsProductAssembly;
        }

        /// Сохранение сборок по указанным товарам в файл-Word
        public void SaveProductAssembliesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new ListAssemblyInfoStorekeeper
            {
                FileName = model.FileName,
                Title = "Список сборок по указанным товарам",
                AssemblyProduct = GetAssemblyProduct(model.Products)
            });
        }

        /// Сохранение сборок по указанным товарам в файл-Excel
        public void SaveProductAssembliesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ListAssemblyInfoStorekeeper
            {
                FileName = model.FileName,
                Title = "Список сборок по указанным товарам",
                AssemblyProduct = GetAssemblyProduct(model.Products)
            });
        }

        /// Сохранение отчета продаж комплектующих в файл-Pdf
        public void SaveComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfoStorekeeper
            {
                FileName = model.FileName,
                Title = "Список использованных комплектующих",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                ComponentProductAssembly = GetComponentProductAssembly(model)
            });
        }
    }
}