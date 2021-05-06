using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using NLog;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreViewSellerWpf
{
    public class GridProductComponent
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly ProductLogic logicP;
        private readonly ComponentLogic logicC;
        private int? id;
        private Dictionary<int, (string, int, decimal)> productComponents;
        private readonly Logger logger;

        public ProductWindow(ProductLogic logicP, ComponentLogic logicC)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicC = logicC;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void ProductWindow_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ProductViewModel view = logicP.Read(new ProductBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxProductName.Text = view.ProductName;
                        textBoxPrice.Text = view.Price.ToString();
                        productComponents = view.Components;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка загрузки данных : " + ex.Message);
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
                    dataGridComponents.Items.Clear();
                    foreach (var pc in productComponents)
                    {
                        dataGridComponents.Items.Add(new GridProductComponent
                        { 
                            Id = pc.Key,
                            ComponentName = pc.Value.Item1,
                            Count = pc.Value.Item2,
                            Price = pc.Value.Item3
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddComponent_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<ProductComponentsWindow>();
            if (form.ShowDialog() == true)
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

        private void buttonChangeComponent_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComponents.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<ProductComponentsWindow>();
                int id = ((GridProductComponent)dataGridComponents.SelectedItems[0]).Id;
                form.Id = id;
                form.Count = productComponents[id].Item2;
                form.Price = productComponents[id].Item3;
                if (form.ShowDialog() == true)
                {
                    productComponents[form.Id] = (form.ComponentName, form.Count, form.Price);
                    LoadData();
                }
            }
        }

        private void buttonDeleteComponent_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComponents.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        productComponents.Remove(((GridProductComponent)dataGridComponents.SelectedItems[0]).Id);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка при удалении записи : " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonUpdateComponents_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicP.CreateOrUpdate(new ProductBindingModel
                {
                    Id = id,
                    ProductName = textBoxProductName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    Components = productComponents,
                    SellerId = App.Seller.Id
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
            this.DialogResult = false;
            Close();
        }
    }
}
