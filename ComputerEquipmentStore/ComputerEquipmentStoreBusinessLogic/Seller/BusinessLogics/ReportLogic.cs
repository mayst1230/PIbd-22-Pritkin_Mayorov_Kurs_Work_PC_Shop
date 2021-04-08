using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.HelperModels;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using System.Collections.Generic;


namespace ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IPurchaseStorage _purchaseStorage;
        private readonly IProductStorage _productStorage;
        private readonly IAssemblyStorage _assemblyStorage;
        private readonly IComponentStorage _componentStorage;

        public ReportLogic(IPurchaseStorage purchaseStorage, IProductStorage productStorage, IAssemblyStorage assemblyStorage, IComponentStorage componentStorage)
        {
            _productStorage = productStorage;
            _purchaseStorage = purchaseStorage;
            _assemblyStorage = assemblyStorage;
            _componentStorage = componentStorage;
        }

        private List<ReportAssemblyProductViewModel> GetAssemblyProduct(List<ProductViewModel> selectedProducts)
        {
            List<ReportAssemblyProductViewModel> record = new List<ReportAssemblyProductViewModel>();
            var listAssembly = _assemblyStorage.GetFullList();
            foreach (var assembly in listAssembly)
            {
                Dictionary<int, (string, decimal)> neededProducts = new Dictionary<int, (string, decimal)>();
                foreach (var product in selectedProducts)
                {
                    bool needed = true;
                    foreach (var component in product.Components)
                    {
                        if (!assembly.Components.ContainsKey(component.Key))
                        {
                            needed = false;
                        }
                    }
                    if (needed)
                    {
                        neededProducts.Add(product.Id, (product.ProductName, product.Price));
                    }
                }
                if (neededProducts.Count > 0)
                {
                    record.Add(new ReportAssemblyProductViewModel
                    {
                        AssemblyName = assembly.AssemblyName,
                        Products = neededProducts
                    });    
                }
            }
            return record;
        }

        //Получение списка комплектующих с указанием товаров и сборок за определенный период
        public List<ReportComponentsViewModel> GetComponentProductAssembly(ReportBindingModel model)
        {
            var purchases = _purchaseStorage.GetFilteredList(new PurchaseBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });

            var componentsProductAssembly = new List<ReportComponentsViewModel>();
            foreach (var purchase in purchases)
            {
                foreach (var product in purchase.Products)
                
                {
                    var view = _productStorage.GetElement(new ProductBindingModel {
                        Id = product.Key
                    });
                    foreach (var component in view.Components)
                    {
                        componentsProductAssembly.Add(new ReportComponentsViewModel
                        {
                            Component = component.Value.Item1,
                            DataSale = purchase.DatePurchase,
                            AssemblyProduct = view.ProductName
                        });
                    }
                }
                foreach (var assembly in purchase.Assemblies)
                {
                    var view = _assemblyStorage.GetElement(new AssemblyBindingModel
                    {
                        Id = assembly.Key
                    });
                    foreach (var component in view.Components)
                    {
                        componentsProductAssembly.Add(new ReportComponentsViewModel
                        {
                            Component = component.Value.Item1,
                            DataSale = purchase.DatePurchase,
                            AssemblyProduct = view.AssemblyName
                        });
                    }
                }
            }
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
    }
}