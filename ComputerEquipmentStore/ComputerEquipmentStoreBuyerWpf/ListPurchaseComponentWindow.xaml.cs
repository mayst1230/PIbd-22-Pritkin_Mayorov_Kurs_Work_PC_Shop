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
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using SWF = System.Windows.Forms;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для ListPurchaseComponentWindow.xaml
    /// </summary>
    public partial class ListPurchaseComponentWindow : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogicBuyer reportLogic;

        public ListPurchaseComponentWindow(ReportLogicBuyer reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
        }

        private void buttonToExcwl_Click(object sender, RoutedEventArgs e)
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
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
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
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
        }
    }
}
