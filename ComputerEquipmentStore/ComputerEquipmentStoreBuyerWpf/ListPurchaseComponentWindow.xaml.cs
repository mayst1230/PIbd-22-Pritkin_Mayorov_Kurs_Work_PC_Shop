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
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using SWF = System.Windows.Forms;
using NLog;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для ListPurchaseComponentWindow.xaml
    /// </summary>
    public partial class ListPurchaseComponentWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogicBuyer reportLogic;

        private readonly PurchaseLogic purchaseLogic;

        private List<PurchaseViewModel> purchases = new List<PurchaseViewModel>();

        private readonly Logger logger;

        public ListPurchaseComponentWindow(PurchaseLogic purchaseLogic, ReportLogicBuyer reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
            this.purchaseLogic = purchaseLogic;
            logger = LogManager.GetCurrentClassLogger();

            var list = purchaseLogic.Read(new PurchaseBindingModel { BuyerId = App.Buyer.Id });
            if (list != null)
            {
                comboBoxPurchases.ItemsSource = list;
            }
        }

        private void buttonToExcel_Click(object sender, RoutedEventArgs e)
        {
            using (SWF.SaveFileDialog dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == SWF.DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SavePurchaseComponentToExcelFile(new ReportBindingModelBuyer
                        {
                            FileName = dialog.FileName
                        },
                        purchases);
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Ошибка при создании документа EXCEL: " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }     
            }
        }

        private void buttonToWord_Click(object sender, RoutedEventArgs e)
        {
            using (SWF.SaveFileDialog dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {          
                if (dialog.ShowDialog() == SWF.DialogResult.OK)
                {
                    reportLogic.SavePurchaseComponentToWordFile(new ReportBindingModelBuyer
                    {
                        FileName = dialog.FileName
                    },
                    purchases);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
        }

        private void buttonAddPurchase_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPurchases.SelectedValue == null)
            {
                MessageBox.Show("Выберите покупку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                {
                    Id = int.Parse(comboBoxPurchases.SelectedValue.ToString())
                })?[0];

                if (purchases != null) {

                    foreach (var purchase in purchases)
                    {
                        if (purchase.Id == view.Id)
                        {
                            MessageBox.Show("Эта покупка уже есть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    purchases.Add(view);
                    LoadData();
                }
                else
                {
                    purchases.Add(view);
                    LoadData();
                }
            }
        }

        private void buttonRemovePurchase_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPurchases.SelectedValue == null)
            {
                MessageBox.Show("Выберите покупку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                PurchaseViewModel view = purchaseLogic.Read(new PurchaseBindingModel
                {
                    Id = int.Parse(comboBoxPurchases.SelectedValue.ToString())
                })?[0];


                if (purchases != null)
                {
                    foreach (var purchase in purchases)
                    {
                        if (purchase.Id == view.Id)
                        {
                            purchases.Remove(purchase);
                            LoadData();
                            return;
                        }
                    }
                }

                MessageBox.Show("Эта покупки нет в списке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadData()
        {
            listBoxPurchases.Items.Clear();
            foreach (var purchase in purchases)
            {
                listBoxPurchases.Items.Add(purchase.PurchaseName);
            }
        }
    }
}
