using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreDatabaseImplement.Implements;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;

namespace ComputerEquipmentStoreView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
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
            currentContainer.RegisterType<IAssemblyStorage, AssemblyStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICommentStorage, CommentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBuyerStorage, BuyerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AssemblyLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CommentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PurchaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BuyerLogic>(new HierarchicalLifetimeManager());
            //currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
