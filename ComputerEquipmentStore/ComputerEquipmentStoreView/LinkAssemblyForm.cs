using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;

namespace ComputerEquipmentStoreView
{
    public partial class LinkAssemblyForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        private readonly AssemblyLogic assemblyLogic;

        private Dictionary<int, (string, int, decimal)> purchaseAssemblies;

        private int id;

        public int Id { set { id = value; } }

        public string AssemblyName {
            get { return textBoxAssembly.Text; }
            set { textBoxAssembly.Text = value; }
        }


        public LinkAssemblyForm(PurchaseLogic purchaseLogic, AssemblyLogic assemblyLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
            this.assemblyLogic = assemblyLogic;

            List<PurchaseViewModel> list = purchaseLogic.Read(null);
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
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxCost.Text = (count * assembly?.Cost ?? 0).ToString();
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
                })?[0];
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {


            MessageBox.Show("При изменении индекса. " + comboBoxPurchase.SelectedValue.ToString(), "Текущий индекс", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                {
                    Id = int.Parse(comboBoxPurchase.SelectedValue.ToString())
                })?[0];
                if (view != null)
                {
                    purchaseAssemblies = view.Assemblies;
                    if (purchaseAssemblies == null)
                    {
                        MessageBox.Show("При изменение индекса. purchaseAssemblies == null", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
