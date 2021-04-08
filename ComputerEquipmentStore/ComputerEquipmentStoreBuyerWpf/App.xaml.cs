using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreDatabaseImplement.Implements;
using ComputerStoreEquipmentDatabaseImplement.Implements;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BuyerViewModel Buyer { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();
            var authWindow = container.Resolve<AuthorizationWindowBuyer>();
            authWindow.ShowDialog();      
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISellerStorage, SellerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAssemblyStorage, AssemblyStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICommentStorage, CommentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBuyerStorage, BuyerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SellerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AssemblyLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PurchaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CommentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BuyerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogicBuyer>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
