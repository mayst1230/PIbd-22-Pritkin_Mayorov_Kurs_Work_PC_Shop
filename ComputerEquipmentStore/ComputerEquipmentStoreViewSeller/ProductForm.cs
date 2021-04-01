using System;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System.Windows.Forms;
using System.Collections.Generic;
using Unity;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class ProductForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ProductLogic logic;
        private int? id;
        private Dictionary<int, (string, int, decimal)> productComponents;
        public ProductForm(ProductLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ProductViewModel view = logic.Read(new ProductBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxProductName.Text = view.ProductName;
                        textBoxProductPrice.Text = view.Price.ToString();
                        productComponents = view.Components;
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
                productComponents = new Dictionary<int, (string, int, decimal)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (productComponents != null)
                {
                    dataGridViewComponents.Rows.Clear();
                    foreach (var pc in productComponents)
                    {
                        dataGridViewComponents.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3});
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ProductComponentsForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (productComponents.ContainsKey(form.Id))
                {
                    productComponents[form.Id] = (form.ComponentName, form.Count, form.Price);
                }
                else
                {
                    productComponents.Add(form.Id, (form.ComponentName, form.Count, form.Price));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<ProductComponentsForm>();
                int id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = productComponents[id].Item2;
                form.Price = productComponents[id].Item3;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productComponents[form.Id] = (form.ComponentName, form.Count, form.Price);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        productComponents.Remove(Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxProductPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productComponents == null || productComponents.Count == 0)
            {
                MessageBox.Show("Заполните комплектующее", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new ProductBindingModel
                {
                    Id = id,
                    ProductName = textBoxProductName.Text,
                    Price = Convert.ToDecimal(textBoxProductPrice.Text),
                    Components = productComponents,
                    SellerId = Program.Seller.Id
                });
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
