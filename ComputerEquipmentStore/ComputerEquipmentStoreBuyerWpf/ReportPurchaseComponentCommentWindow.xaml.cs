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
using ComputerEquipmentStoreBusinessLogic.HelperModels;

using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;

namespace ComputerEquipmentStoreBuyerWpf
{
    /// <summary>
    /// Логика взаимодействия для ReportPurchaseComponentCommentWindow.xaml
    /// </summary>
    public partial class ReportPurchaseComponentCommentWindow : Window
    {
        public class DataGridItemReportPurchaseComponentComment
        {
            public string Purchasename { get; set; }

            public DateTime DatePurchase { get; set; }

            public string Component { get; set; }

            public string CountOfComponent { get; set; }

            public string Comment { get; set; }

            public DateTime DateComment { get; set; }
        }

        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogicBuyer reportLogic;

        private readonly Logger logger;

        public ReportPurchaseComponentCommentWindow(ReportLogicBuyer reportLogic)
        {
            InitializeComponent();
            this.reportLogic = reportLogic;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void buttonCreateReport_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate == null || DatePickerTo.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = reportLogic.GetInfoAboutPurchases(new ReportBindingModelBuyer
                {
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate
                });


                List<DataGridItemReportPurchaseComponentComment> list = new List<DataGridItemReportPurchaseComponentComment>(); 
                    
                //dataGrid.    Row.Background = new SolidColorBrush(Colors.Green);

                foreach (var line in dataSource)
                {

                    list.Add(new DataGridItemReportPurchaseComponentComment
                    {
                        Purchasename = line.PurchaseName,
                        DatePurchase = line.DatePurchase
                    });

                    foreach (var component in line.Components)
                    {
                        list.Add(new DataGridItemReportPurchaseComponentComment
                        {
                            Component = component.Item1,
                            CountOfComponent = component.Item2.ToString()
                        });
                    }

                    foreach (var comment in line.Comments)
                    {
                        list.Add(new DataGridItemReportPurchaseComponentComment
                        {
                            Comment = comment.Item1,
                            DateComment = comment.Item2
                        });
                    }
                }

                dataGrid.ItemsSource = list;
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка вывода отчета в PDF на форму: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void buttonToPdf_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerFrom.SelectedDate == null || DatePickerFrom.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                        logger.Error("Ошибка формирования отчета в PDF: " + ex.Message);
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        [Obsolete]
        private void buttonToEmail_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerTo.SelectedDate == null || DatePickerFrom.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Не выбраны даты для отчета");
                return;
            }

            if (DatePickerFrom.SelectedDate >= DatePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Выбранная дата начала больше, чем дата окончания");
                return;
            }
            try
            {
                var fileName = "Report.pdf";
                reportLogic.SaveToPdfFile(new ReportBindingModelBuyer
                {
                    FileName = fileName,
                    DateFrom = DatePickerFrom.SelectedDate,
                    DateTo = DatePickerTo.SelectedDate
                });

                MailLogic.MailSend(new MailSendInfo
                {
                    MailAddress = App.Buyer.Login,
                    Subject = "Отчет по комплектующим",
                    Text = "Отчет по комплектующим от " + DatePickerFrom.SelectedDate.Value.ToShortDateString() + " по " + DatePickerTo.SelectedDate.Value.ToShortDateString(),
                    FileName = fileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка отправки отчета: " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
