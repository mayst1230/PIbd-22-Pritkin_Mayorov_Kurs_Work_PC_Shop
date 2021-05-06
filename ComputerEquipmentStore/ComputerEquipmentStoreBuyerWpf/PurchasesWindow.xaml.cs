using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using NLog;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для PurchasesWindow.xaml
    /// </summary>
    public partial class PurchasesWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        private readonly Logger logger;

        public PurchasesWindow(PurchaseLogic purchaseLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void PurchasesWindow_Load(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = purchaseLogic.Read(null, App.Buyer.Id);
                if (list != null)
                {
                    dataGridPurchases.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при загрузке данных о покупках: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<PurchaseWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPurchases.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<PurchaseWindow>();
                form.Id = ((PurchaseViewModel)dataGridPurchases.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPurchases.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((PurchaseViewModel)dataGridPurchases.SelectedItems[0]).Id;
                    try
                    {
                        purchaseLogic.Delete(new PurchaseBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка при удалении покупки: " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRefrash_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
