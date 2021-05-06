using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ProductLogic logic;

        public ProductsWindow(ProductLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ProductsWindow_Loaded(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridProducts.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ProductWindow>();
            if (form.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProducts.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<ProductWindow>();
                form.Id = ((ProductViewModel)dataGridProducts.SelectedItems[0]).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProducts.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int id = ((ProductViewModel)dataGridProducts.SelectedItems[0]).Id;
                    try
                    {
                        logic.Delete(new ProductBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
