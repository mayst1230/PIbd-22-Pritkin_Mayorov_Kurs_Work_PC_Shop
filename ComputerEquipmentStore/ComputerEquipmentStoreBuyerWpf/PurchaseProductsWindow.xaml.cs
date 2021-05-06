using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для PurchaseProductsWindow.xaml
    /// </summary>
    public partial class PurchaseProductsWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        private readonly ProductLogic productLogic;

        public int Id
        {
            get { return Convert.ToInt32(comboBoxProducts.SelectedValue); }
            set { comboBoxProducts.SelectedValue = value; }
        }


        public string NameOfProduct { get { return comboBoxProducts.Text; } }


        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public decimal Price
        {
            get { return Convert.ToDecimal(textBoxCost.Text); }
            set
            {
                textBoxCost.Text = value.ToString();
            }
        }


        public PurchaseProductsWindow(PurchaseLogic purchaseLogic, ProductLogic productLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
            this.productLogic = productLogic;

            var list = productLogic.Read(null);
            if (list != null)
            {
                comboBoxProducts.ItemsSource = list;
            }
        }

        

        





        private void CalcSum()
        {
            if (comboBoxProducts.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProducts.SelectedValue);
                    ProductViewModel product = productLogic.Read(new ProductBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxCost.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void comboBoxProducts_SelectionChanged(object sender, EventArgs e)
        {
            CalcSum();
        }



        private void textBoxCount_TextChanged(object sender, RoutedEventArgs e)
        {
            CalcSum();
        }

        private void textBoxCount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProducts.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = true;
            Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
