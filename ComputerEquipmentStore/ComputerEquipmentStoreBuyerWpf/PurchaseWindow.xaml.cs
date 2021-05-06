using Unity;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using NLog;

namespace ComputerEquipmentStoreBuyerWpf
{

    public class GridPurchaseProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    }

    public class GridPurchaseAssembly
    {
        public int Id { get; set; }
        public string AssemblyName { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для PurchaseWindowBuyer.xaml
    /// </summary>
    public partial class PurchaseWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        public int Id { set { id = value; } }

        private int? id;

        private Dictionary<int, (string, int, decimal)> purchaseProducts;

        private Dictionary<int, (string, int, decimal)> purchaseAssemblies;

        private readonly Logger logger;

        public PurchaseWindow(PurchaseLogic purchaseLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void PurchaseWindow_Load(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                    {
                        Id = id.Value
                    }, App.Buyer.Id)?[0];
                    if (view != null)
                    {
                        textBoxNamePurchase.Text = view.PurchaseName;
                        datePickerPurchaseDate.SelectedDate = view.DatePurchase;
                        purchaseProducts = view.Products;
                        purchaseAssemblies = view.Assemblies;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка при загрузки данных о покупке: " + ex.Message);
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
                    dataGridProducts.Items.Clear();
                    foreach (var purchaseProduct in purchaseProducts)
                    {
                        dataGridProducts.Items.Add(new GridPurchaseProduct
                        {
                            Id = purchaseProduct.Key,
                            ProductName = purchaseProduct.Value.Item1,
                            Count = purchaseProduct.Value.Item2,
                            Cost = purchaseProduct.Value.Item3
                        });
                    }
                }

                if (purchaseAssemblies != null)
                {
                    dataGridAssemblies.Items.Clear();
                    foreach (var assemblyComponent in purchaseAssemblies)
                    {
                        dataGridAssemblies.Items.Add(new GridPurchaseAssembly
                        {
                            Id = assemblyComponent.Key,
                            AssemblyName = assemblyComponent.Value.Item1,
                            Count = assemblyComponent.Value.Item2,
                            Cost = assemblyComponent.Value.Item3
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при привязке сборки к покупке: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            
            var form = Container.Resolve<PurchaseProductsWindow>();
            if (form.ShowDialog() == true)
            {
                if (purchaseProducts.ContainsKey(form.Id))
                {
                    purchaseProducts[form.Id] = (form.NameOfProduct, form.Count, form.Price);
                }
                else
                {
                    purchaseProducts.Add(form.Id, (form.NameOfProduct, form.Count, form.Price));
                }
                LoadData();
            }
            
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            
            if (dataGridProducts.SelectedItems.Count == 1)
            {
                var form = Container.Resolve<PurchaseProductsWindow>();

                int id = Convert.ToInt32(dataGridProducts.SelectedItems[0]);
                form.Id = id;
                form.Count = purchaseProducts[id].Item2;
                form.Price = purchaseProducts[id].Item3;
                if (form.ShowDialog() == true)
                {
                    purchaseProducts[form.Id] = (form.NameOfProduct, form.Count, form.Price);
                    LoadData();
                }
            }
            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProducts.SelectedItems.Count == 1)
            {
                MessageBoxResult result = (MessageBoxResult)MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        purchaseProducts.Remove(((ProductViewModel)dataGridProducts.SelectedItems[0]).Id);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка при удалении продукта из покупки: " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNamePurchase.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePickerPurchaseDate.SelectedDate == null)
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
                    DatePurchase = Convert.ToDateTime(datePickerPurchaseDate.SelectedDate),
                    BuyerId = App.Buyer.Id,
                    TotalCost = (int)totalCost,
                    Products = purchaseProducts,
                    Assemblies = purchaseAssemblies
                }); ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при сохранении покупки: " + ex.Message);
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
