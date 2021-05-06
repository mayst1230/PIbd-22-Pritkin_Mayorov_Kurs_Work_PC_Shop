using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerStoreEquipmentDatabaseImplement.Implements;
using ComputerEquipmentStoreDatabaseImplement.Implements;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;

namespace ComputerEquipmentStoreViewSeller
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        public static SellerViewModel Seller { get; set; }
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<AuthorizationFormSeller>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISellerStorage, SellerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAssemblyStorage, AssemblyStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrderLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SellerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AssemblyLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
