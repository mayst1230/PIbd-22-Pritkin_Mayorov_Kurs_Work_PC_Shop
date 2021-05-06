using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class OrderForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic _orderLogic;
       
        public OrderForm(OrderLogic orderLogic)
        {
            InitializeComponent();
            this._orderLogic = orderLogic;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _orderLogic.Read(null);
                if (list != null)
                {
                    dataGridViewOrders.DataSource = list;
                    dataGridViewOrders.Columns[0].Visible = false;
                    dataGridViewOrders.Columns[1].Visible = false;
                    dataGridViewOrders.Columns[2].Visible = false;
                    dataGridViewOrders.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<OrderCreateForm>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonUpdateOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<OrderCreateForm>();
                int id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id =
               Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.Delete(new OrderBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }
    }
}
