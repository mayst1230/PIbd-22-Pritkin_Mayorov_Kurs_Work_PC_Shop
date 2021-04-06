using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;

namespace ComputerEquipmentStoreView
{
    public partial class PurchaseForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        public int Id { set { id = value; } }
        
        private int? id;

        private Dictionary<int, (string, int, decimal)> purchaseProducts;

        private Dictionary<int, (string, int, decimal)> purchaseAssemblies;


        public PurchaseForm(PurchaseLogic purchaseLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
        }



        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxNamePurchase.Text = view.PurchaseName;
                        dateTimePickerDatePurchase.Text = view.DatePurchase.ToString();
                        purchaseProducts = view.Products;
                        purchaseAssemblies = view.Assemblies;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                purchaseProducts = new Dictionary<int, (string, int, decimal)>();
                purchaseAssemblies = new Dictionary<int, (string, int, decimal)>();
            }
        }



        private void LoadData()
        {
            try
            {
                if (purchaseProducts != null)
                {
                    dataGridViewProducts.Rows.Clear();
                    foreach (var product in purchaseProducts)
                    {
                        dataGridViewProducts.Rows.Add(new object[] { product.Key, product.Value.Item1, product.Value.Item2, product.Value.Item3 });
                    }
                }

                if (purchaseAssemblies != null)
                {
                    dataGridViewAssemblies.Rows.Clear();
                    foreach (var assembly in purchaseAssemblies)
                    {
                        dataGridViewAssemblies.Rows.Add(new object[] { assembly.Key, assembly.Value.Item1, assembly.Value.Item2, assembly.Value.Item3 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<PurchaseProductsForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (purchaseProducts.ContainsKey(form.Id))
                {
                    purchaseProducts[form.Id] = (form.ProductName, form.Count, form.Price);
                }
                else
                {
                    purchaseProducts.Add(form.Id, (form.ProductName, form.Count, form.Price));
                }
                LoadData();
            }
        }







        private void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<PurchaseProductsForm>();
                int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = purchaseProducts[id].Item2;
                form.Price = purchaseProducts[id].Item3;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    purchaseProducts[form.Id] = (form.ProductName, form.Count, form.Price);
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        purchaseProducts.Remove(Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        

        private void ButtonSaveProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNamePurchase.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(dateTimePickerDatePurchase.Text))
            {
                MessageBox.Show("Заполните дату покупки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (purchaseProducts == null || purchaseProducts.Count == 0)
            {
                MessageBox.Show("Заполните продукты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {


                decimal totalCost = 0;

                foreach (var product in purchaseProducts)
                {
                    totalCost += product.Value.Item3;
                }

                foreach (var assembly in purchaseAssemblies)
                {
                    totalCost += assembly.Value.Item3;
                }

                purchaseLogic.CreateOrUpdate(new PurchaseBindingModel
                {
                    Id = id,
                    PurchaseName = textBoxNamePurchase.Text,
                    DatePurchase = Convert.ToDateTime(dateTimePickerDatePurchase.Text),
                    Products = purchaseProducts,




                    BuyerId = Program.Buyer.Id,
                    TotalCost = (int) totalCost

                    

                }); ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
    }
}
