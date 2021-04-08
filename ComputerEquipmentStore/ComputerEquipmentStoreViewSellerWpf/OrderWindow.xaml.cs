using Unity;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;
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

        public OrderWindow(OrderLogic logic)
        {
            InitializeComponent();
            this._orderLogic = logic;
        }

        private void OrderWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _orderLogic.Read(null);
                if (list != null)
                {
                    dataGridOrders.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
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
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
