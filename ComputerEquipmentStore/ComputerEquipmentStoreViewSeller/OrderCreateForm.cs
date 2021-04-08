using ComputerEquipmentStoreBusinessLogic.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputerEquipmentStoreViewSeller
{
    public partial class OrderCreateForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ProductLogic _logicP;
        private readonly OrderLogic _logicO;
        private int? id;

        public string OrderName
        { 
            get { return textBoxOrderName.Text; }
            set { textBoxOrderName.Text = value.ToString(); }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public OrderCreateForm(ProductLogic logicP, OrderLogic logicO)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logicP.Read(null);
                if (list != null)
                {
                    comboBoxProduct.DataSource = list;
                    comboBoxProduct.DisplayMember = "ProductName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (id.HasValue)
            { 
                try
                {
                    var list = _logicO.Read(new OrderBindingModel { 
                        Id = id.Value
                    })?[0];
                    if (list != null)
                    {
                        comboBoxProduct.SelectedValue = list.ProductId;
                        textBoxCount.Text = list.Count.ToString();
                        textBoxOrderName.Text = list.OrderName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrUpdate(new OrderBindingModel
                {
                    Id = id,
                    ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    SellerId = Program.Seller.Id,
                    OrderName = textBoxOrderName.Text,
                    Count = Convert.ToInt32(textBoxCount.Text)
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
