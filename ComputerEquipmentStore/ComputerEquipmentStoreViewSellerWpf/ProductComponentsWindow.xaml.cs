using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для ProductComponentsWindow.xaml
    /// </summary>
    public partial class ProductComponentsWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ComponentLogic _logic;
        public int Id
        {
            get { return Convert.ToInt32(comboBoxComponent.SelectedValue); }
            set { comboBoxComponent.SelectedValue = value; }
        }

        public string ComponentName { get { return comboBoxComponent.Text; } }

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
            get { return Convert.ToDecimal(textBoxPrice.Text); }
            set
            {
                textBoxPrice.Text = value.ToString();
            }
        }

        public ProductComponentsWindow(ComponentLogic logic)
        {
            InitializeComponent();
            this._logic = logic;

            List<ComponentViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxComponent.ItemsSource = list;
                comboBoxComponent.DisplayMemberPath = "ComponentName";
                comboBoxComponent.SelectedItem = null;
            }
        }

        private void CalcSum()
        {
            if (comboBoxComponent.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = (int)comboBoxComponent.SelectedValue;
                    ComponentViewModel component = _logic.Read(new ComponentBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxPrice.Text = (count * component?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите комплектующее", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
