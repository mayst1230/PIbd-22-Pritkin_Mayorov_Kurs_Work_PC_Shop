using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using NLog;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    
    public partial class OrderWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly OrderLogic _orderLogic;
        private readonly Logger logger;

        public OrderWindow(OrderLogic logic)
        {
            InitializeComponent();
            this._orderLogic = logic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void OrderWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _orderLogic.Read(new OrderBindingModel { SellerId = App.Seller.Id});
                if (list != null)
                {
                    dataGridOrders.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<OrderCreateWindow>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridOrders.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<OrderCreateWindow>();
                form.Id = ((OrderViewModel)dataGridOrders.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridOrders.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((OrderViewModel)dataGridOrders.SelectedItems[0]).Id;
                    try
                    {
                        _orderLogic.Delete(new OrderBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка при удалении записи : " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}