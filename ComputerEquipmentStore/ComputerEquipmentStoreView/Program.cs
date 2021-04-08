using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Seller.Interfaces;
using ComputerEquipmentStoreDatabaseImplement.Implements;
using ComputerStoreEquipmentDatabaseImplement.Implements;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;

namespace ComputerEquipmentStoreView
{
    static class Program
    {
         
        public static BuyerViewModel Buyer { get; set; }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        ///
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<AuthorizationFormBuyer>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IBuyerStorage, BuyerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAssemblyStorage, AssemblyStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICommentStorage, CommentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentStorage, ComponentStorage>(new HierarchicalLifetimeManager());


            currentContainer.RegisterType<BuyerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PurchaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AssemblyLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CommentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ProductLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComponentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogicBuyer>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
