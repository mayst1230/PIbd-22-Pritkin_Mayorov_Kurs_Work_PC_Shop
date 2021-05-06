using ComputerEquipmentStoreBusinessLogic.Seller.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Seller.BusinessLogics;
using ComputerEquipmentStoreBusinessLogic.HelperModels;
using System;
using NLog;
using System.Windows;
using System.Windows.Forms;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;
using SWF = System.Windows.Forms;

namespace ComputerEquipmentStoreViewSellerWpf
{
    /// <summary>
    /// Логика взаимодействия для ReportComponentProductAssemblyWindow.xaml
    /// </summary>
    public partial class ReportComponentProductAssemblyWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly Logger logger;

        public ReportComponentProductAssemblyWindow(ReportLogic logicR)
        {
            InitializeComponent();
            logic = logicR;
            logger = LogManager.GetCurrentClassLogger();
        }

        private void buttonSaveToPdf_Click(object sender, RoutedEventArgs e)
        {
            if (DatePikerFrom.SelectedDate >= DatePikerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SWF.SaveFileDialog dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == SWF.DialogResult.OK)
                {

                    try
                    {
                        logic.SaveComponentsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = DatePikerFrom.SelectedDate,
                            DateTo = DatePikerTo.SelectedDate,
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCreateList_Click(object sender, RoutedEventArgs e)
        {
            if (DatePikerTo.SelectedDate == null || DatePikerFrom.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DatePikerFrom.SelectedDate >= DatePikerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = logic.GetComponentProductAssembly(new ReportBindingModel
                {
                    DateFrom = DatePikerFrom.SelectedDate,
                    DateTo = DatePikerTo.SelectedDate
                });
                dataGridList.ItemsSource = dataSource;
                
            }
            catch (Exception ex)
            {
                logger.Error("Ошибка формирования отчета : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToPdfInEmail_Click(object sender, RoutedEventArgs e)
        {
            if (DatePikerTo.SelectedDate == null || DatePikerFrom.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Не выбраны даты для отчета");
                return;
            }

            if (DatePikerFrom.SelectedDate >= DatePikerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("Выбранная дата начала больше, чем дата окончания");
                return;
            }
            try
            {
                var fileName = "Report.pdf";
                logic.SaveComponentsToPdfFile(new ReportBindingModel
                {
                    FileName = fileName,
                    DateFrom = DatePikerFrom.SelectedDate,
                    DateTo = DatePikerTo.SelectedDate
                });
                MailLogic.MailSend(new MailSendInfo
                {
                    MailAddress = App.Seller.Login,
                    Subject = "Отчет по комплектующим",
                    Text = "Отчет по комплектующим от " + DatePikerFrom.SelectedDate.Value.ToShortDateString() + " по " + DatePikerTo.SelectedDate.Value.ToShortDateString(),
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