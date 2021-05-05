using System;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System.Windows.Forms;
using Unity;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class ProductsForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ProductLogic logic;

        public ProductsForm(ProductLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
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
                    dataGridViewProducts.DataSource = list;
                    dataGridViewProducts.Columns[0].Visible = false;
                    dataGridViewProducts.Columns[1].Visible = false;
                    dataGridViewProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewProducts.Columns[3].Visible = false;
                    dataGridViewProducts.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<ProductForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<ProductForm>();
                form.Id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells[0].Value);
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

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
