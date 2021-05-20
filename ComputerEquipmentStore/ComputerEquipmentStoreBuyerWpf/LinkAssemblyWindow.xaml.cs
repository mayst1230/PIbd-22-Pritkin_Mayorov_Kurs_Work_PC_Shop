using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Unity;
using ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Seller.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using NLog;

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


        //Список сборок выбранной покупки
        private Dictionary<int, (string, int, decimal)> purchaseAssemblies;

        private int id;

        public int Id { set { id = value; } }

        private readonly Logger logger;

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
            logger = LogManager.GetCurrentClassLogger();

            var list = purchaseLogic.Read(new PurchaseBindingModel { BuyerId = App.Buyer.Id });
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

                    textBoxCost.Text = (Convert.ToInt32(textBoxCount.Text) * assembly.Cost).ToString();
                }
                catch (Exception ex)
                {
                    logger.Error("Ошибка при подсчете стоимости: " + ex.Message);
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
                })?[0];

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
                            Products = view.Products,
                            Assemblies = purchaseAssemblies,
                        });
                        logger.Info("Сохранение привязки сборки к покупки прошло успешно");
                        MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при привязке сборки к покупке: " + ex.Message);
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
                })?[0];
                if (view != null)
                {
                    purchaseAssemblies = view.Assemblies;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка при изменении индекса в комбобоксе покупки: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
