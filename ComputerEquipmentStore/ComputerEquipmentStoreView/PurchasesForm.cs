using System;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using System.Windows.Forms;
using Unity;

namespace ComputerEquipmentStoreView
{
    public partial class PurchasesForm : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        public PurchasesForm(PurchaseLogic purchaseLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
        }

        private void PurchasesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = purchaseLogic.Read(null, Program.Buyer.Id);
                if (list != null)
                {
                    dataGridViewPurchases.DataSource = list;
                    dataGridViewPurchases.Columns[0].Visible = false;//
                    dataGridViewPurchases.Columns[1].Visible = true;//
                    dataGridViewPurchases.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewPurchases.Columns[3].Visible = true;//
                    dataGridViewPurchases.Columns[4].Visible = true;//
                    dataGridViewPurchases.Columns[5].Visible = false;//
                    dataGridViewPurchases.Columns[6].Visible = false;//

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<PurchaseForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewPurchases.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<PurchaseForm>();
                form.Id = Convert.ToInt32(dataGridViewPurchases.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPurchases.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewPurchases.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        purchaseLogic.Delete(new PurchaseBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
