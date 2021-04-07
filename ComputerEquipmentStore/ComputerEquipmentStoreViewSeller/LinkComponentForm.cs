using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class LinkComponentForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ComponentLogic componentLogic;

        private readonly AssemblyLogic assemblyLogic;

        private Dictionary<int, (string, int, decimal)> assemblyComponents;

        private int id;//id компонента

        public int Id { set { id = value; } }

        public string ComponentName
        {
            get { return textBoxComponent.Text; }
            set { textBoxComponent.Text = value; }
        }

        public LinkComponentForm(ComponentLogic componentLogic, AssemblyLogic assemblyLogic)
        {
            InitializeComponent();
            this.componentLogic = componentLogic;
            this.assemblyLogic = assemblyLogic;

            
            var listAssemblies = assemblyLogic.Read(null);
            if (listAssemblies != null)
            {
                comboBoxAssembly.DisplayMember = "AssemblyName";
                comboBoxAssembly.ValueMember = "Id";
                comboBoxAssembly.DataSource = listAssemblies;
            }
            
        }









        /// <summary>
        /// Подсчитать стоимость комплектующих конкретного типа в сборке
        /// </summary>
        private decimal CalculateTotalCostAssembly()
        {
            if (!string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    if (comboBoxAssembly.SelectedValue != null)
                    {
                        AssemblyViewModel assembly = assemblyLogic.Read(new AssemblyBindingModel
                        {
                            Id = int.Parse(comboBoxAssembly.SelectedValue.ToString())
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

        private void buttonLinkComponent_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(textBoxCost.Text))
            {
                MessageBox.Show("Поле суммы почему то пусто", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                AssemblyViewModel view = assemblyLogic.Read(new AssemblyBindingModel
                {
                    Id = int.Parse(comboBoxAssembly.SelectedValue.ToString())
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
                        assemblyComponents[id] = (ComponentName, int.Parse(textBoxCount.Text), decimal.Parse(textBoxCost.Text));
                        MessageBox.Show("Привязка id", "Привязка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        assemblyLogic.CreateOrUpdate(new AssemblyBindingModel
                        {
                            Id = view.Id,
                            AssemblyName = view.AssemblyName,
                            BuyerId = view.BuyerId,
                            Cost = view.Cost,
                            Components = assemblyComponents,
                        }); ;
                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        assemblyComponents.Add(id, (ComponentName, int.Parse(textBoxCount.Text), decimal.Parse(textBoxCost.Text)));
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AssemblyViewModel view = assemblyLogic.Read(new AssemblyBindingModel
                {
                    Id = int.Parse(comboBoxAssembly.SelectedValue.ToString())
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

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void CalcSum()
        {
            if (comboBoxAssembly.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxAssembly.SelectedValue);
                    ComponentViewModel component = componentLogic.Read(new ComponentBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxCost.Text = (count * component?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
