using Unity;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для AssemblyComponentWindow.xaml
    /// </summary>
    public partial class AssemblyComponentWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ComponentLogic componentLogic;
        private readonly AssemblyLogic assemblyLogic;
        private Dictionary<int, (string, int, decimal)> assemblyComponents;
        private int? id;//id компонента

        public int Id { set { id = value; } }

        public string ComponentName
        {
            get { return textBoxComponent.Text; }
            set { textBoxComponent.Text = value; }
        }

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

        public AssemblyComponentWindow(ComponentLogic componentLogic, AssemblyLogic assemblyLogic)
        {
            InitializeComponent();
            this.componentLogic = componentLogic;
            this.assemblyLogic = assemblyLogic;

            var listAssemblies = assemblyLogic.Read(null);
            if (listAssemblies != null)
            {
                comboBoxAssembly.ItemsSource = listAssemblies;
                comboBoxAssembly.DisplayMemberPath = "AssemblyName";
                comboBoxAssembly.SelectedItem = null;
            }
        }

        private decimal CalculateTotalCostAssembly()
        {
            if (!string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    if (comboBoxAssembly.SelectedValue != null)
                    {
                        int id = (int)comboBoxAssembly.SelectedValue;
                        AssemblyViewModel assembly = assemblyLogic.Read(new AssemblyBindingModel
                        {
                            Id = id
                        })?[0];
                        int count = Convert.ToInt32(textBoxCount.Text);

                        decimal costOfAssembly = 0;
                        if (assembly.Components != null)
                        {
                            foreach (var componentId in assembly.Components)
                            {
                                ComponentViewModel component = componentLogic.Read(new ComponentBindingModel
                                {
                                    Id = componentId.Key
                                })?[0];
                                costOfAssembly += component.Price;
                            }
                        }
                        return count * costOfAssembly;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxAssembly.SelectedValue == null)
            {
                MessageBox.Show("Выберите сборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните поле Стоимость", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int id = (int)comboBoxAssembly.SelectedValue;
                AssemblyViewModel view = assemblyLogic.Read(new AssemblyBindingModel
                {
                    Id = id
                })?[0];

                if (view != null)
                {
                    if (view.Components != null)
                    {
                        if (view.Components.ContainsKey(id))
                        {
                            MessageBox.Show("Это комплектующее уже привязаоно к этой сборке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (assemblyComponents.ContainsKey(id))
                    {
                        assemblyComponents[id] = (ComponentName, int.Parse(textBoxCount.Text), decimal.Parse(textBoxPrice.Text));
                        MessageBox.Show("Привязка id", "Привязка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        assemblyLogic.CreateOrUpdate(new AssemblyBindingModel
                        {
                            Id = view.Id,
                            AssemblyName = view.AssemblyName,
                            BuyerId = view.BuyerId,
                            Cost = CalculateTotalCostAssembly(),
                            Components = assemblyComponents,
                        }); ;
                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        assemblyComponents.Add(id, (ComponentName, int.Parse(textBoxCount.Text), decimal.Parse(textBoxPrice.Text)));
                        MessageBox.Show("Привязка add", "Привязка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        assemblyLogic.CreateOrUpdate(new AssemblyBindingModel
                        {
                            Id = view.Id,
                            AssemblyName = view.AssemblyName,
                            BuyerId = view.BuyerId,
                            Cost = CalculateTotalCostAssembly(),
                            Components = assemblyComponents
                        });
                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CalcSum()
        {
            if (comboBoxAssembly.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    //int id = (int)comboBoxAssembly.SelectedValue;
                    ComponentViewModel component = componentLogic.Read(new ComponentBindingModel
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

        private void comboBoxAssembly_SelectedChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int id = (int)comboBoxAssembly.SelectedValue;
                AssemblyViewModel view = assemblyLogic.Read(new AssemblyBindingModel
                {
                    Id = id
                })?[0];
                if (view != null)
                {
                    assemblyComponents = view.Components;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxCount_TextChange(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CalcSum();
        }
    }
}
