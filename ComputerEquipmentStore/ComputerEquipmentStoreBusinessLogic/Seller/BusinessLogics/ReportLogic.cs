/*using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System.Collections.Generic;


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

        private Dictionary<int, ReportAssemblyProductViewModel> GetAssemblyProduct(List<ProductViewModel> selectedProducts)
        {
            List<PurchaseViewModel> purchase = GetPurchaseByProducts(selectedProducts);
            Dictionary<int, ReportAssemblyProductViewModel> record = new Dictionary<int, ReportAssemblyProductViewModel>();
            foreach (PurchaseViewModel p in purchase)
            {
                foreach (KeyValuePair<int, (string, int)> assembly in p.Assemblies)
                {
                    if (!record.ContainsKey(assembly.Key))
                    {
                        record.Add(assembly.Key, new ReportAssemblyProductViewModel
                        {
                            AssemblyName = assembly.Value.Item1,
                            Products = new Dictionary<int, (string, decimal)>()
                        });
                    }
                    foreach (var product in p.Products)
                    {
                        foreach (var selectedProduct in selectedProducts)
                        {
                            if (product.Key == selectedProduct.Id)
                            {
                                if (!record[assembly.Key].Products.ContainsKey(product.Key))
                                {
                                    var productModel = _productStorage.GetElement(new ProductBindingModel
                                    {
                                        Id = product.Key
                                    });
                                    record[assembly.Key].Products.Add(product.Key, (product.Value.Item1, productModel != null ? productModel.Price : 0));
                                }
                            }
                        }
                    }
                }
            }
            return record;
        }

        private List<PurchaseViewModel> GetPurchaseByProducts(List<ProductViewModel> selectedProducts)
        {
            List<PurchaseViewModel> purchases = _purchaseStorage.GetFullList();
            List<PurchaseViewModel> neededPurchase = new List<PurchaseViewModel>();
            foreach (PurchaseViewModel p in purchases)
            {
                bool purchaseIsNeeded = false;
                foreach (KeyValuePair<int, (string, int)> product in p.Products)
                {
                    if (purchaseIsNeeded)
                    {
                        break;
                    }
                    foreach (ProductViewModel selectedProduct in selectedProducts)
                    {
                        if (product.Key == selectedProduct.Id)
                        {
                            purchaseIsNeeded = true;
                            break;
                        }
                    }
                }
                if (purchaseIsNeeded)
                {
                    if (!neededPurchase.Contains(p))
                    {
                        neededPurchase.Add(p);
                    }
                }
            }
            return neededPurchase;
        }

        // Получение списка запчастей с указанием работ и машин за определенный период
        public List<ReportComponentsViewModel> GetSparePartWorkCar(ReportBindingModel model)
        {
            var purchase = _purchaseStorage.GetFilteredList(new PurchaseBindingModel
            {
                DatePurchase = model.DatePurchase
            });

            var componentsProductAssembly = new List<ReportComponentsViewModel>();
            foreach (var purchases in purchase)
            {
                var product = _productStorage.GetElement(new ProductBindingModel
                {
                    Id = 
                });
                foreach (var purchaseAssembly in purchase.)
                {
                    var poroduct = _productStorage.GetElement(new ProductBindingModel
                    {
                        Id = purchaseAssembly.Key
                    });
                    foreach (var sparePart in poroduct.WorkSpareParts)
                    {
                        componentsProductAssembly.Add(new ReportSparePartsViewModel
                        {
                            CarName = product.CarName,
                            DatePassed = product.DatePassed,
                            WorkName = poroduct.WorkName,
                            SparePart = sparePart.Value.Item1
                        });
                    }
                }
            }
            return componentsProductAssembly;
        }
    }
}
*/