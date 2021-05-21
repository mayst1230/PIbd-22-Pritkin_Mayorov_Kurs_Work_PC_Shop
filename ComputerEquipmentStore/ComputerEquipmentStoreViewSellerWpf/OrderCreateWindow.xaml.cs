using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using System;
using System.Windows;
using System.Windows.Forms;
using NLog;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для OrderCreateWindow.xaml
    /// </summary>
    public partial class OrderCreateWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ProductLogic _logicP;
        private readonly OrderLogic _logicO;
        public int Id { set { id = value; } }
        private int? id;
        private readonly Logger logger;

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

        public OrderCreateWindow(ProductLogic logicP, OrderLogic logicO)
        {
            InitializeComponent();
            _logicP = logicP;
            _logicO = logicO;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void OrderCreateWindow_Loaded(object sender, EventArgs e)
        {
            try
            {
                var list = _logicP.Read(new ProductBindingModel { SellerId = App.Seller.Id });
                if (list != null)
                {
                    comboBoxProduct.ItemsSource = list;
                    comboBoxProduct.DisplayMemberPath = "ProductName";
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (id.HasValue)
            {
                try
                {
                    var list = _logicO.Read(new OrderBindingModel
                    {
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
                    logger.Error("Ошибка загрузки данных : " + ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
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
                    SellerId = App.Seller.Id,
                    OrderName = textBoxOrderName.Text,
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при сохранении данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
