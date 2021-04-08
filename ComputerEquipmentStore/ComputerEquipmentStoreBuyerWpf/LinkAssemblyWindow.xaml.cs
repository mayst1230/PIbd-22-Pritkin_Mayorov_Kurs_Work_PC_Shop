using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.BindingModels;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для LinkAssemblyWindow.xaml
    /// </summary>
    public partial class LinkAssemblyWindow : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly PurchaseLogic purchaseLogic;

        private readonly AssemblyLogic assemblyLogic;

        private readonly ComponentLogic componentLogic;

        private Dictionary<int, (string, int, decimal)> purchaseAssemblies;

        private int id;

        public int Id { set { id = value; } }

        public string AssemblyName
        {
            get { return textBoxAssembly.Text; }
            set { textBoxAssembly.Text = value; }
        }

        public LinkAssemblyWindow(PurchaseLogic purchaseLogic, AssemblyLogic assemblyLogic, ComponentLogic componentLogic)
        {
            InitializeComponent();
            this.purchaseLogic = purchaseLogic;
            this.assemblyLogic = assemblyLogic;
            this.componentLogic = componentLogic;


            var list = purchaseLogic.Read(null, App.Buyer.Id);
            if (list != null)
            {
                comboBoxPurchase.ItemsSource = list;
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

                    decimal costOfAssembly = 0;
                    if (assembly.Components != null)
                    {
                        foreach (var componentId in assembly.Components)
                        {
                            ComponentViewModel component = componentLogic.Read(new ComponentBindingModel
                            {
                                Id = componentId.Key
                            })?[0];

                            costOfAssembly += component.Price;
                        }
                    }

                    textBoxCost.Text = (count * costOfAssembly).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void buttonLink_Click(object sender, RoutedEventArgs e)
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
                }, App.Buyer.Id)?[0];

                if (view.Assemblies.ContainsKey(id))
                {
                    MessageBox.Show("Эта сборка уже привязана к этой покупке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void textBoxCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcSum();
        }

        private void comboBoxPurchase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                {
                    Id = int.Parse(comboBoxPurchase.SelectedValue.ToString())
                }, App.Buyer.Id)?[0];
                if (view != null)
                {
                    purchaseAssemblies = view.Assemblies;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
