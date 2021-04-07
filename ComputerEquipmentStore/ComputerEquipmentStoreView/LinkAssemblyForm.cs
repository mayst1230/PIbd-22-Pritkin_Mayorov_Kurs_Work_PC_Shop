using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BindingModels;

namespace ComputerEquipmentStoreView
{
    public partial class LinkAssemblyForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        private readonly AssemblyLogic assemblyLogic;

        private readonly ComponentLogic componentLogic;

        private Dictionary<int, (string, int, decimal)> purchaseAssemblies;

        private int id;

        public int Id { set { id = value; } }

        public string AssemblyName {
            get { return textBoxAssembly.Text; }
            set { textBoxAssembly.Text = value; }
        }

        public LinkAssemblyForm(PurchaseLogic purchaseLogic, AssemblyLogic assemblyLogic, ComponentLogic componentLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
            this.assemblyLogic = assemblyLogic;
            this.componentLogic = componentLogic;

            List<PurchaseViewModel> list = purchaseLogic.Read(null, Program.Buyer.Id);
            if (list != null)
            {
                comboBoxPurchase.DisplayMember = "PurchaseName";
                comboBoxPurchase.ValueMember = "Id";
                comboBoxPurchase.DataSource = list;
            }  
        }

        /// <summary>
        /// Подсчитать стоимость сборки (по комплектующим)
        /// </summary>
        private void CalcSum()
        {
            if (!string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    AssemblyViewModel assembly = assemblyLogic.Read(new AssemblyBindingModel
                    {
                        Id = id
                    }, Program.Buyer.Id)?[0];
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

                    textBoxCost.Text = (count * costOfAssembly).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Привязать сборку к покупке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLinkAssembly_Click(object sender, EventArgs e)
        {
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
                PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                {
                    Id = int.Parse(comboBoxPurchase.SelectedValue.ToString())
                }, Program.Buyer.Id)?[0];

                if (view.Assemblies.ContainsKey(id))
                {
                    MessageBox.Show("Эта сборка уже привязана к этой покупке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (view != null)
                {
                    if (purchaseAssemblies.ContainsKey(id))
                    {
                        purchaseAssemblies[id] = (AssemblyName, int.Parse(textBoxCount.Text), decimal.Parse(textBoxCost.Text));
                        MessageBox.Show("Привязка id", "Привязка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        purchaseLogic.CreateOrUpdate(new PurchaseBindingModel
                        {
                            Id = view.Id,
                            PurchaseName = view.PurchaseName,
                            BuyerId = view.BuyerId,
                            DatePurchase = view.DatePurchase,
                            TotalCost = view.TotalCost,
                            Products = view.Products,
                            Assemblies = purchaseAssemblies,
                        }); ;
                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        purchaseAssemblies.Add(id, (AssemblyName, int.Parse(textBoxCount.Text), decimal.Parse(textBoxCost.Text)));
                        MessageBox.Show("Привязка add", "Привязка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        purchaseLogic.CreateOrUpdate(new PurchaseBindingModel
                        {
                            Id = view.Id,
                            PurchaseName = view.PurchaseName,
                            BuyerId = view.BuyerId,
                            DatePurchase = view.DatePurchase,
                            TotalCost = view.TotalCost,
                            Products = view.Products,
                            Assemblies = purchaseAssemblies,
                        }); ;
                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        /// <summary>
        /// При нажатии кнопки отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// При смене количества сборок в текстовом поле количества сборок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        /// <summary>
        /// При смене покупки в комбобоксе выбора покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                {
                    Id = int.Parse(comboBoxPurchase.SelectedValue.ToString())
                }, Program.Buyer.Id)?[0];
                if (view != null)
                {
                    purchaseAssemblies = view.Assemblies;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
