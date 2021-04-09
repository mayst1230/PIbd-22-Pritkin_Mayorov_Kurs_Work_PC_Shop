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

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для ReportPurchaseComponentCommentWindow.xaml
    /// </summary>
    public partial class ReportPurchaseComponentCommentWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogicBuyer reportLogic;

        public ReportPurchaseComponentCommentWindow(ReportLogicBuyer reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
        }

        private void buttonCreateReport_Click(object sender, RoutedEventArgs e)
        {
            //Сформировать отчет
        }

        private void buttonToPdf_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SWF.SaveFileDialog dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == SWF.DialogResult.OK)
                {
                    try
                    {
                        reportLogic.SaveToPdfFile(new ReportBindingModelBuyer
                        {
                            FileName = dialog.FileName,
                            DateFrom = DatePickerFrom.SelectedDate,
                            DateTo = DatePickerTo.SelectedDate
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

        private void buttonToEmail_Click(object sender, RoutedEventArgs e)
        {
            //Отправить отчет на почту
        }
    }
}
